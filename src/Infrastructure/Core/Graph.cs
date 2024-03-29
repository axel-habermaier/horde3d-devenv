using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;

namespace Infrastructure.Core
{
	/// <summary>
	/// A base class for graphs.
	/// </summary>
	/// <typeparam name="TIdentifier">The type of the node's identifiers.</typeparam>
	/// <typeparam name="TNode">The type of the graph's nodes.</typeparam>
	public abstract class Graph<TIdentifier, TNode> where TNode : class
	{
		#region Private Fields and Properties
		/// <summary>
		/// Time to wait after the last change before raising the ResourceGraphChanged event.
		/// </summary>
		const int DelayTimeInMilliseconds = 300;

		/// <summary>
		/// Maps an identifier to a T instance.
		/// </summary>
		Dictionary<TIdentifier, TNode> nodes = new Dictionary<TIdentifier, TNode>();

		/// <summary>
		/// Gets a function that gets a node's identifier.
		/// </summary>
		protected abstract Func<TNode, TIdentifier> NodeIdentifier { get; }

		/// <summary>
		/// Used to delay the invocation of the GraphChanged event.
		/// </summary>
		private DelayedEventRaiser<GraphChangedEventArgs<TNode>> delayedEvent;
		#endregion

		#region Public Properties and Indexers
		/// <summary>
		/// Gets a list of all nodes.
		/// </summary>
		public ReadOnlyCollection<TNode> Nodes
		{
			get
			{ 
				lock (nodes)
					return nodes.Values.ToList().AsReadOnly(); 
			}
		}

		/// <summary>
		/// Gets the node with the specified identifier.
		/// </summary>
		/// <param name="identifier">The identifier of the node that should be returned.</param>
		/// <returns>Returns the node with the given identifier. If the node does not exist, null is returned.</returns>
		public TNode this[TIdentifier identifier]
		{
			get
			{
				lock (nodes)
				{
					if (!nodes.ContainsKey(identifier))
						return null;

					return nodes[identifier];
				}
			}
		}
		#endregion

		#region Events
		/// <summary>
		/// Raised when the graph has changed. This event is raised on a background thread.
		/// </summary>
		public event EventHandler<GraphChangedEventArgs<TNode>> GraphChanged
		{
			add { delayedEvent.DelayElapsed += value; }
			remove { delayedEvent.DelayElapsed -= value; }
		}
		#endregion

		/// <summary>
		/// Initializes a new resource graph instance.
		/// </summary>
		public Graph()
		{
			delayedEvent = new DelayedEventRaiser<GraphChangedEventArgs<TNode>>(() => new GraphChangedEventArgs<TNode>(Nodes));
		}

		/// <summary>
		/// Adds the given resource to the list of known resources.
		/// </summary>
		/// <param name="node">The node that should be added.</param>
		public void Add(TNode node)
		{
			lock (nodes)
				nodes.Add(NodeIdentifier(node), node);
			delayedEvent.RaiseEvent(DelayTimeInMilliseconds);
		}

		/// <summary>
		/// Clears the list of known resources.
		/// </summary>
		public void Clear()
		{
			lock (nodes)
				nodes.Clear();
			delayedEvent.RaiseEvent(DelayTimeInMilliseconds);
		}
	}

	#region Delegates and EventArgs
	/// <summary>
	/// A class containing further details when the GraphChanged event is handled.
	/// </summary>
	/// <typeparam name="T">The type of the graph's nodes.</typeparam>
	public class GraphChangedEventArgs<T> : EventArgs
	{
		/// <summary>
		/// Gets the node list.
		/// </summary>
		public ReadOnlyCollection<T> Nodes { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="nodes">The node list.</param>
		public GraphChangedEventArgs(ReadOnlyCollection<T> nodes)
		{
			Nodes = nodes;
		}
	}
	#endregion
}
