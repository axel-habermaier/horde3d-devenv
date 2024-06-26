﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Core.Communication;
using Infrastructure.Core.Messages;
using Infrastructure.Core.Misc;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Resources;
using System.Drawing;
using System.ServiceModel;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace Client.Models
{
	[ServiceBehavior(UseSynchronizationContext = false, IncludeExceptionDetailInFaults = true)]
	class CallbackHandler : IDebuggerServiceCallback
	{
		#region Events
		/// <summary>
		/// Raised when the Horde3D application generated a new message.
		/// Might be raised on a background thread.
		/// </summary>
		public event MessageGeneratedHandler MessageGenerated;

		/// <summary>
		/// Raised when the Horde3D application has just been suspended and is now sending a function call that was logged.
		/// Might be raised on a background thread.
		/// </summary>
		public event FunctionCallAddedHandler FunctionCallAdded;

		/// <summary>
		/// Raised when the Horde3D application has just been suspended and is now sending a scene node.
		/// Might be raised on a background thread.
		/// </summary>
		public event SceneNodeAddedHandler SceneNodeAdded;

		/// <summary>
		/// Raised when the Horde3D application has just been suspended and is now sending a resource.
		/// Might be raised on a background thread.
		/// </summary>
		public event ResourceAddedHandler ResourceAdded;

		/// <summary>
		/// Raised when the Horde3D application has just been suspended.
		/// Might be raised on a background thread.
		/// </summary>
		public event SuspendedHandler Suspended;

		/// <summary>
		/// Raised when the Horde3D application has just been resumed.
		/// Might be raised on a background thread.
		/// </summary>
		public event ResumedHandler Resumed;

		/// <summary>
		/// Raised when the Horde3D application has just been profiled.
		/// </summary>
		public event ProfiledHandler Profiled;
		#endregion

		#region Callback Implementation
		/// <summary>
		/// Called when a message was generated by the server.
		/// </summary>
		/// <param name="message">The message that was generated.</param>
		public void OnMessageGenerated(Message message)
		{
			VerifyThread();
			if (MessageGenerated != null)
				MessageGenerated(this, new MessageGeneratedEventArgs(message));
		}

		/// <summary>
		/// Called when the application was suspended.
		/// </summary>
		public void OnSuspended()
		{
			VerifyThread();
			if (Suspended != null)
				Suspended(this, SuspendedEventArgs.Empty);
		}

		/// <summary>
		/// Called when the application was resumed.
		/// </summary>
		public void OnResumed()
		{
			VerifyThread();
			if (Resumed != null)
				Resumed(this, ResumedEventArgs.Empty);
		}

		/// <summary>
		/// Called when the application was profiled.
		/// </summary>
		public void OnProfiled()
		{
			VerifyThread();
			if (Profiled != null)
				Profiled(this, ProfiledEventArgs.Empty);
		}

		/// <summary>
		/// Sends a scene node to the client.
		/// </summary>
		/// <param name="sceneNode">The scene node that should be sent.</param>
		public void AddSceneNode(SceneNode sceneNode)
		{
			VerifyThread();
			sceneNode.SceneGraph = DebuggerShell.Current.SceneGraph;
			if (SceneNodeAdded != null)
				SceneNodeAdded(this, new SceneNodeAddedEventArgs(sceneNode));
		}

		/// <summary>
		/// Sends a resource to the client.
		/// </summary>
		/// <param name="resource">The resource that should be sent.</param>
		public void AddResource(Resource resource)
		{
			VerifyThread();
			resource.ResourceGraph = DebuggerShell.Current.ResourceGraph;
			if (ResourceAdded != null)
				ResourceAdded(this, new ResourceAddedEventArgs(resource));
		}

		/// <summary>
		/// Sends a function call info object to the client.
		/// </summary>
		/// <param name="functionCall">The function call that was logged.</param>
		public void AddFunctionCall(FunctionCall functionCall)
		{
			VerifyThread();
			if (FunctionCallAdded != null)
				FunctionCallAdded(this, new FunctionCallAddedEventArgs(functionCall));
		}
		#endregion

		[Conditional("DEBUG")]
		private void VerifyThread()
		{
			Debug.Assert(Thread.CurrentThread.Name != "H3DDevEnv", "Callback invoked on the main thread.");
		}
	}

	#region Delegates and EventArgs
	/// <summary>
	/// Delegated used by the MessageGenerated event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void MessageGeneratedHandler(object sender, MessageGeneratedEventArgs e);

	/// <summary>
	/// A class containing further details when the MessageGenerated event is handled.
	/// </summary>
	public class MessageGeneratedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the generated message.
		/// </summary>
		public Message Message { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="message">The generated message.</param>
		public MessageGeneratedEventArgs(Message message)
		{
			Message = message;
		}
	}

	/// <summary>
	/// Delegated used by the FunctionCallAdded event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void FunctionCallAddedHandler(object sender, FunctionCallAddedEventArgs e);

	/// <summary>
	/// A class containing further details when the FunctionCallAdded event is handled.
	/// </summary>
	public class FunctionCallAddedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the function call that should be added.
		/// </summary>
		public FunctionCall FunctionCall { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="functionCall">The function call that should be added.</param>
		public FunctionCallAddedEventArgs(FunctionCall functionCall)
		{
			FunctionCall = functionCall;
		}
	}

	/// <summary>
	/// Delegated used by the SceneNodeAdded event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void SceneNodeAddedHandler(object sender, SceneNodeAddedEventArgs e);

	/// <summary>
	/// A class containing further details when the SceneNodeAdded event is handled.
	/// </summary>
	public class SceneNodeAddedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the scene node that should be added.
		/// </summary>
		public SceneNode SceneNode { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="sceneNode">The scene node that should be added.</param>
		public SceneNodeAddedEventArgs(SceneNode sceneNode)
		{
			SceneNode = sceneNode;
		}
	}

	/// <summary>
	/// Delegated used by the ResourceAdded event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void ResourceAddedHandler(object sender, ResourceAddedEventArgs e);

	/// <summary>
	/// A class containing further details when the ResourceAdded event is handled.
	/// </summary>
	public class ResourceAddedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets the resource that should be added.
		/// </summary>
		public Resource Resource { get; private set; }

		/// <summary>
		/// Creates a new instance.
		/// </summary>
		/// <param name="resource">The resource that should be added.</param>
		public ResourceAddedEventArgs(Resource resource)
		{
			Resource = resource;
		}
	}

	/// <summary>
	/// Delegated used by the Suspended event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void SuspendedHandler(object sender, SuspendedEventArgs e);

	/// <summary>
	/// A class containing further details when the Suspended event is handled.
	/// </summary>
	public class SuspendedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets an empty default instance.
		/// </summary>
		public static new SuspendedEventArgs Empty { get; private set; }

		/// <summary>
		/// Initializes the Empty property.
		/// </summary>
		static SuspendedEventArgs()
		{
			Empty = new SuspendedEventArgs();
		}
	}

	/// <summary>
	/// Delegated used by the Resumed event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void ResumedHandler(object sender, ResumedEventArgs e);

	/// <summary>
	/// A class containing further details when the Resumed event is handled.
	/// </summary>
	public class ResumedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets an empty default instance.
		/// </summary>
		public static new ResumedEventArgs Empty { get; private set; }

		/// <summary>
		/// Initializes the Empty property.
		/// </summary>
		static ResumedEventArgs()
		{
			Empty = new ResumedEventArgs();
		}
	}

	/// <summary>
	/// Delegated used by the Profiled event.
	/// </summary>
	/// <param name="sender">The event's source.</param>
	/// <param name="e">Further information associated with the event.</param>
	public delegate void ProfiledHandler(object sender, ProfiledEventArgs e);

	/// <summary>
	/// A class containing further details when the Profiled event is handled.
	/// </summary>
	public class ProfiledEventArgs : EventArgs
	{
		/// <summary>
		/// Gets an empty default instance.
		/// </summary>
		public static new ProfiledEventArgs Empty { get; private set; }

		/// <summary>
		/// Initializes the Empty property.
		/// </summary>
		static ProfiledEventArgs()
		{
			Empty = new ProfiledEventArgs();
		}
	}
	#endregion
}
