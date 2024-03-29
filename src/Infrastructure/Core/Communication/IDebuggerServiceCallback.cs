﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Infrastructure.Core.Messages;
using Infrastructure.Core.Misc;
using Infrastructure.Core.SceneNodes;
using Infrastructure.Core.Resources;
using System.Drawing;

namespace Infrastructure.Core.Communication
{
	[DeliveryRequirements(RequireOrderedDelivery = true)]
	public interface IDebuggerServiceCallback
	{
		/// <summary>
		/// Called when a message was generated by the server.
		/// </summary>
		/// <param name="message">The message that was generated.</param>
		[OperationContract]
		[ServiceKnownType(typeof(Horde3DMessage))]
		void OnMessageGenerated(Message message);

		/// <summary>
		/// Called when the application was suspended.
		/// </summary>
		[OperationContract]
		void OnSuspended();

		/// <summary>
		/// Called when the application was resumed.
		/// </summary>
		[OperationContract]
		void OnResumed();

		/// <summary>
		/// Called when the application was profiled.
		/// </summary>
		[OperationContract]
		void OnProfiled();

		/// <summary>
		/// Sends a scene node to the client.
		/// </summary>
		/// <param name="sceneNode">The scene node that should be sent.</param>
		[ServiceKnownType(typeof(CameraNode))]
		[ServiceKnownType(typeof(EmitterNode))]
		[ServiceKnownType(typeof(GroupNode))]
		[ServiceKnownType(typeof(JointNode))]
		[ServiceKnownType(typeof(LightNode))]
		[ServiceKnownType(typeof(MeshNode))]
		[ServiceKnownType(typeof(ModelNode))]
		[OperationContract]
		void AddSceneNode(SceneNode sceneNode);

		/// <summary>
		/// Sends a resource to the client.
		/// </summary>
		/// <param name="resource">The resource that should be sent.</param>
		[ServiceKnownType(typeof(AnimationResource))]
		[ServiceKnownType(typeof(CodeResource))]
		[ServiceKnownType(typeof(EditableResource))]
		[ServiceKnownType(typeof(GeometryResource))]
		[ServiceKnownType(typeof(MaterialResource))]
		[ServiceKnownType(typeof(ParticleEffectResource))]
		[ServiceKnownType(typeof(PipelineResource))]
		[ServiceKnownType(typeof(SceneGraphResource))]
		[ServiceKnownType(typeof(ShaderResource))]
		[ServiceKnownType(typeof(TextureResource))]
		[OperationContract]
		void AddResource(Resource resource);

		/// <summary>
		/// Sends a function call info object to the client.
		/// </summary>
		/// <param name="functionCall">The function call that was logged.</param>
		[OperationContract]
		void AddFunctionCall(FunctionCall functionCall);
	}
}
