using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Resources;

namespace Infrastructure.Core.Communication
{
	[ServiceContract(CallbackContract = typeof(IDebuggerServiceCallback))]
	[DeliveryRequirements(RequireOrderedDelivery = true)]
	public interface IDebuggerService
	{
		/// <summary>
		/// Registers the client callback.
		/// </summary>
		[OperationContract]
		void RegisterClient();

		/// <summary>
		/// Suspends the execution of the application.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(InvalidOperationException))]
		void Suspend();

		/// <summary>
		/// Resumes the execution of the application.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(InvalidOperationException))]
		void Resume();

		/// <summary>
		/// Profiles the application.
		/// </summary>
		[OperationContract]
		void Profile();

		/// <summary>
		/// Asks the server to send the debug information using the callback contract.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(InvalidOperationException))]
		void RequestDebugData();

		/// <summary>
		/// Asks the server to profile a frame and send the information using the callback contract.
		/// </summary>
		[OperationContract]
		void RequestFrameProfilingData();

		/// <summary>
		/// Copies the changes made to the given resource to the resource currently used by the application.
		/// </summary>
		/// <param name="resource">The resource that should be updated.</param>
		[OperationContract]
		[FaultContract(typeof(InvalidOperationException))]
		[ServiceKnownType(typeof(ShaderResource))]
		[ServiceKnownType(typeof(PipelineResource))]
		[ServiceKnownType(typeof(CodeResource))]
		[ServiceKnownType(typeof(MaterialResource))]
		[ServiceKnownType(typeof(ParticleEffectResource))]
		void UpdateResource(EditableResource resource);

		/// <summary>
		/// Gets the current data of the specified render target.
		/// </summary>
		/// <param name="pipelineResHandle">The render target's pipeline's resource handle.</param>
		/// <param name="renderTargetName">The render target's name.</param>
		/// <param name="colorBufferIndex">The color buffer index.</param>
		[OperationContract]
		byte[] GetRenderTargetData(int pipelineResHandle, string renderTargetName, int colorBufferIndex);
	}
}
