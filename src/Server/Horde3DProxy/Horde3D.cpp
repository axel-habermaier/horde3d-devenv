// *************************************************************************************************
// Horde3D Visual Debugger
//
// Axel Habermaier
// Bachelor Thesis, University of Augsburg, 2008/2009
// *************************************************************************************************
//
// All exported Horde3D functions must be defined in this file. All Horde3D proxy functions must
// eventually call their real Horde3D counterpart and return its value.
// See also: "Horde3DProxy.h", "Horde3DInterop.h".
//
// Currently compatible to Horde3D version: Horde3D 1.0.0 Beta2.
// *************************************************************************************************

#include "Horde3DProxy.h"
#include "Horde3D.h"

// *************************************************************************************************
// Engine core functions
// *************************************************************************************************

namespace Horde3D
{
	using namespace System::Windows::Forms;
	// *********************************************************************************************
	// Basic functions
	// *********************************************************************************************

	DLL const char *getVersionString()
	{
		const char* r = Horde3DProxy::InitializedInstance()->GetVersionString();
		Horde3DProxy::Instance()->FunctionCall("getVersionString", gcnew String(r));
		return r;
	}


	DLL bool checkExtension( const char *extensionName )
	{
		bool r = Horde3DProxy::InitializedInstance()->CheckExtension(extensionName);
		Horde3DProxy::Instance()->FunctionCall("checkExtension", r, gcnew String(extensionName));
		return r;
	}


	DLL bool init()
	{
		bool r = Horde3DProxy::InitializedInstance()->Init();
		Horde3DProxy::Instance()->FunctionCall("init", r);

		//static bool first = true;

		//if (first)
		//{
		//	HDC hdc = wglGetCurrentDC();
		//	if (hdc != NULL)
		//	{
		//		HWND hwnd = WindowFromDC(hdc);
		//		//SetWindowLongPtr(hwnd, GWLP_WNDPROC, (LONG_PTR)MyWinProc);
		//		Form^ f = gcnew Form();
		//		//f->Size = gcnew Size(800, 600);
		//		f->Show();

		//		IntPtr i(hwnd);
		//		Control^ g = Form::FromHandle(i);
		//		g->Show();
		//	}



		//	first = false;
		//}

		return r;
	}


	DLL void release()
	{
		Horde3DProxy::InitializedInstance()->Release();
		Horde3DProxy::Instance()->FunctionCall("release", nullptr);
	}


	DLL bool render( NodeHandle cameraNode )
	{
		bool r = Horde3DProxy::InitializedInstance()->Render(cameraNode);
		Horde3DProxy::Instance()->FunctionCall("render", r, (int)cameraNode);
		return r;
	}


	DLL void resize( int x, int y, int width, int height )
	{
		Horde3DProxy::InitializedInstance()->Resize(x, y, width, height);
		Horde3DProxy::Instance()->FunctionCall("resize", nullptr, x, y, width, height);
	}


	DLL void clear()
	{
		Horde3DProxy::InitializedInstance()->Clear();
		Horde3DProxy::Instance()->FunctionCall("clear", nullptr);
	}


	// *********************************************************************************************
	// General functions
	// *********************************************************************************************

	DLL const char *getMessage( int *level, float *time )
	{
		const char* r = Horde3DProxy::InitializedInstance()->GetMessage(level, time);
		Horde3DProxy::Instance()->FunctionCall("getMessage", gcnew String(r), *level, *time);
		return r;
	}


	DLL float getOption( EngineOptions::List param )
	{
		float r = Horde3DProxy::InitializedInstance()->GetOption(param);
		Horde3DProxy::Instance()->FunctionCall("getOption", r, (int)param);
		return r;
	}


	DLL bool setOption( EngineOptions::List param, float value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetOption(param, value);
		Horde3DProxy::Instance()->FunctionCall("setOption", r, (int)param, value);
		return r;
	}


	DLL float getStat( EngineStats::List param, bool reset )
	{
		float r = Horde3DProxy::InitializedInstance()->GetStat(param, reset);
		Horde3DProxy::Instance()->FunctionCall("getStat", r, (int)param, reset);
		return r;
	}


	DLL void showOverlay( float x_ll, float y_ll, float u_ll, float v_ll,
		float x_lr, float y_lr, float u_lr, float v_lr,
		float x_ur, float y_ur, float u_ur, float v_ur,
		float x_ul, float y_ul, float u_ul, float v_ul,
		int layer, ResHandle materialRes )
	{
		Horde3DProxy::InitializedInstance()->ShowOverlay(x_ll, y_ll, u_ll, v_ll, 
			x_lr, y_lr, u_lr, v_lr,
			x_ur, y_ur, u_ur, v_ur,
			x_ul, y_ul, u_ul, v_ul,
			layer, materialRes);
		Horde3DProxy::Instance()->FunctionCall("showOverlay", nullptr, 
			x_ll, y_ll, u_ll, v_ll, 
			x_lr, y_lr, u_lr, v_lr,
			x_ur, y_ur, u_ur, v_ur,
			x_ul, y_ul, u_ul, v_ul,
			layer, materialRes);
	}


	DLL void clearOverlays()
	{
		Horde3DProxy::InitializedInstance()->ClearOverlays();
		Horde3DProxy::Instance()->FunctionCall("clearOverlays", nullptr);
	}


	// *********************************************************************************************
	// Resource functions
	// *********************************************************************************************

	DLL ResourceTypes::List getResourceType( ResHandle res )
	{
		ResourceTypes::List r = Horde3DProxy::InitializedInstance()->GetResourceType(res);
		Horde3DProxy::Instance()->FunctionCall("getResourceType", (int)r, (int)res);
		return r;
	}


	DLL const char *getResourceName( ResHandle res )
	{
		const char* r = Horde3DProxy::InitializedInstance()->GetResourceName(res);	
		Horde3DProxy::Instance()->FunctionCall("getResourceName", gcnew String(r), (int)res);
		return r;
	}


	DLL ResHandle findResource( ResourceTypes::List type, const char *name )
	{
		ResHandle r = Horde3DProxy::InitializedInstance()->FindResource(type, name);
		Horde3DProxy::Instance()->FunctionCall("findResource", (int)r, (int)type, gcnew String(name));
		return r;
	}


	DLL ResHandle addResource( ResourceTypes::List type, const char *name, int flags )
	{
		ResHandle r = Horde3DProxy::InitializedInstance()->AddResource(type, name, flags);
		Horde3DProxy::Instance()->FunctionCall("addResource", (int)r, (int)type, gcnew String(name), flags);
		return r;
	}


	DLL ResHandle cloneResource( ResHandle sourceRes, const char *name )
	{
		ResHandle r = Horde3DProxy::InitializedInstance()->CloneResource(sourceRes, name);
		Horde3DProxy::Instance()->FunctionCall("cloneResource", (int)r, (int)sourceRes, gcnew String(name));
		return r;
	}


	DLL int removeResource( ResHandle res )
	{
		int r = Horde3DProxy::InitializedInstance()->RemoveResource(res);
		Horde3DProxy::Instance()->FunctionCall("removeResource", r, (int)res);
		return r;
	}


	DLL bool isResourceLoaded( ResHandle res )
	{
		bool r = Horde3DProxy::InitializedInstance()->IsResourceLoaded(res);
		Horde3DProxy::Instance()->FunctionCall("isResourceLoaded", r, (int)res);
		return r;
	}

	DLL bool loadResource( ResHandle res, const char *data, int size )
	{
		/*const char* n = getResourceName(res);
		ResourceTypes::List t = getResourceType(res);*/
	
		bool r = Horde3DProxy::InitializedInstance()->LoadResource(res, data, size);
		Horde3DProxy::Instance()->FunctionCall("loadResource", r, (int)res, gcnew String(data), size);
		return r;
	}


	DLL bool unloadResource( ResHandle res )
	{
		bool r = Horde3DProxy::InitializedInstance()->UnloadResource(res);
		Horde3DProxy::Instance()->FunctionCall("unloadResource", r, (int)res);
		return r;
	}


	DLL int getResourceParami( ResHandle res, int param )
	{
		int r = Horde3DProxy::InitializedInstance()->GetResourceParami(res, param);
		Horde3DProxy::Instance()->FunctionCall("getResourceParami", r, (int)res, param);
		return r;
	}


	DLL bool setResourceParami( ResHandle res, int param, int value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetResourceParami(res, param, value);
		Horde3DProxy::Instance()->FunctionCall("setResourceParami", r, (int)res, param, value);
		return r;
	}


	DLL float getResourceParamf( ResHandle res, int param )
	{
		float r = Horde3DProxy::InitializedInstance()->GetResourceParamf(res, param);
		Horde3DProxy::Instance()->FunctionCall("getResourceParamf", r, (int)res, param);
		return r;
	}


	DLL bool setResourceParamf( ResHandle res, int param, float value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetResourceParamf(res, param, value);
		Horde3DProxy::Instance()->FunctionCall("setResourceParamf", r, (int)res, param, value);
		return r;
	}

	DLL const char *getResourceParamstr( ResHandle res, int param )
	{
		const char* r = Horde3DProxy::InitializedInstance()->GetResourceParamstr(res, param);
		Horde3DProxy::Instance()->FunctionCall("getResourceParamstr", gcnew String(r), (int)res, param);
		return r;
	}


	DLL bool setResourceParamstr( ResHandle res, int param, const char *value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetResourceParamstr(res, param, value);
		Horde3DProxy::Instance()->FunctionCall("setResourceParamstr", r, (int)res, param, gcnew String(value));
		return r;
	}

	DLL const void *getResourceData( ResHandle res, int param )
	{
		const void* r = Horde3DProxy::InitializedInstance()->GetResourceData(res, param);
		// We don't know what r is, so we can't send this information to the debugger.
		Horde3DProxy::Instance()->FunctionCall("getResourceData", nullptr, (int)res, param);
		return r;
	}


	DLL bool updateResourceData( ResHandle res, int param, const void *data, int size )
	{
		bool r = Horde3DProxy::InitializedInstance()->UpdateResourceData(res, param, data, size);
		Horde3DProxy::Instance()->FunctionCall("updateResourceData", r, (int)res, param, nullptr, size);
		return r;
	}


	DLL ResHandle queryUnloadedResource( int index )
	{
		ResHandle r = Horde3DProxy::InitializedInstance()->QueryUnloadedResource(index);
		Horde3DProxy::Instance()->FunctionCall("queryUnloadedResource", (int)r, index);
		return r;
	}


	DLL void releaseUnusedResources()
	{
		Horde3DProxy::InitializedInstance()->ReleaseUnusedResources();
		Horde3DProxy::Instance()->FunctionCall("releaseUnusedResources", nullptr);
	}


	DLL ResHandle createTexture2D( const char *name, int flags, int width, int height, bool renderable )
	{
		ResHandle r = Horde3DProxy::InitializedInstance()->CreateTexture2D(name, flags, width, height, renderable);
		Horde3DProxy::Instance()->FunctionCall("createTexture2D", (int)r, gcnew String(name), flags, width, height, renderable);
		return r;
	}


	DLL void setShaderPreambles( const char *vertPreamble, const char *fragPreamble )
	{
		Horde3DProxy::InitializedInstance()->SetShaderPreambles(vertPreamble, fragPreamble);
		Horde3DProxy::Instance()->FunctionCall("setShaderPreambles", gcnew String(vertPreamble), gcnew String(fragPreamble));
	}


	DLL bool setMaterialUniform( ResHandle materialRes, const char *name, float a, float b, float c, float d )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetMaterialUniform(materialRes, name, a, b, c, d);
		Horde3DProxy::Instance()->FunctionCall("setMaterialUniform", r, (int)materialRes, gcnew String(name), a, b, c, d);
		return r;
	}


	DLL bool setPipelineStageActivation( ResHandle pipelineRes, const char *stageName, bool enabled )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetPipelineStageActivation(pipelineRes, stageName, enabled);
		Horde3DProxy::Instance()->FunctionCall("setPipelineStateActivation", r, (int)pipelineRes, gcnew String(stageName), enabled);
		return r;
	}

	/*DLL bool getPipelineRenderTargetData( ResHandle pipelineRes, const char *targetName,
		int bufIndex, int *width, int *height, int *compCount,
		float *dataBuffer, int bufferSize )
	{
		bool r = Horde3DProxy::InitializedInstance()->GetPipelineRenderTargetData(pipelineRes, targetName, bufIndex, width, height, compCount, dataBuffer, bufferSize);
		Horde3DProxy::Instance()->FunctionCall("getPipelineRenderTargetData", r, (int)pipelineRes, gcnew String(targetName),
			bufIndex, *width, *height, *compCount, nullptr, bufferSize);
		return r;
	}*/


	// *********************************************************************************************
	// Scene graph functions
	// *********************************************************************************************

	DLL int getNodeType( NodeHandle node )
	{
		int r = Horde3DProxy::InitializedInstance()->GetNodeType(node);
		Horde3DProxy::Instance()->FunctionCall("getNodeType", r, (int)node);
		return r;
	}


	DLL NodeHandle getNodeParent( NodeHandle node )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->GetNodeParent(node);;
		Horde3DProxy::Instance()->FunctionCall("getNodeParent", (int)r, (int)node);
		return r;
	}


	DLL bool setNodeParent( NodeHandle node, NodeHandle parent )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeParent(node, parent);
		Horde3DProxy::Instance()->FunctionCall("setNodeParent", r, (int)node, (int)parent);
		return r;
	}


	DLL NodeHandle getNodeChild( NodeHandle parent, int index )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->GetNodeChild(parent, index);
		Horde3DProxy::Instance()->FunctionCall("getNOdeChild", (int)r, (int)parent, index);
		return r;
	}


	DLL NodeHandle addNodes( NodeHandle parent, ResHandle sceneGraphRes )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddNodes(parent, sceneGraphRes);
		Horde3DProxy::Instance()->FunctionCall("addNodes", (int)r, (int)parent, (int)sceneGraphRes);
		return r;
	}


	DLL bool removeNode( NodeHandle node )
	{
		bool r = Horde3DProxy::InitializedInstance()->RemoveNode(node);
		Horde3DProxy::Instance()->FunctionCall("removeNode", r, (int)node);
		return r;
	}


	DLL bool setNodeActivation( NodeHandle node, bool active )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeActivation(node, active);
		Horde3DProxy::Instance()->FunctionCall("setNodeActivation", r, (int)node, active);
		return r;
	}


	DLL bool checkNodeTransformFlag( NodeHandle node, bool reset )
	{
		bool r = Horde3DProxy::InitializedInstance()->CheckNodeTransformFlag(node, reset);
		Horde3DProxy::Instance()->FunctionCall("checkNodeTransformFlag", r, (int)node, reset);
		return r;
	}


	DLL bool getNodeTransform( NodeHandle node, float *tx, float *ty, float *tz,
		float *rx, float *ry, float *rz, float *sx, float *sy, float *sz )
	{
		bool r = Horde3DProxy::InitializedInstance()->GetNodeTransform(node, tx, ty, tz, rx, ry, rz, sx, sy, sz);
		Horde3DProxy::Instance()->FunctionCall("getNodeTransform", r, *tx, *ty, *tz, *rx, *ry, *rz, *sx, *sy, *sz);
		return r;
	}


	DLL bool setNodeTransform( NodeHandle node, float tx, float ty, float tz,
		float rx, float ry, float rz, float sx, float sy, float sz )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeTransform(node, tx, ty, tz, rx, ry, rz, sx, sy, sz);
		Horde3DProxy::Instance()->FunctionCall("setNodeTransform", r, tx, ty, tz, rx, ry, rz, sx, sy, sz);
		return r;
	}


	DLL bool getNodeTransformMatrices( NodeHandle node, const float **relMat, const float **absMat )
	{
		bool r = Horde3DProxy::InitializedInstance()->GetNodeTransformMatrices(node, relMat, absMat);
		Horde3DProxy::Instance()->FunctionCall("getNodeTransformMatrices", r, (int)node, nullptr, nullptr);
		return r;
	}


	DLL bool setNodeTransformMatrix( NodeHandle node, const float *mat4x4 )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeTransformMatrix(node, mat4x4);
		Horde3DProxy::Instance()->FunctionCall("setNodeTransformMatrix", r, (int)node, nullptr);
		return r;
	}


	DLL float getNodeParamf( NodeHandle node, int param )
	{
		float r = Horde3DProxy::InitializedInstance()->GetNodeParamf(node, param);
		Horde3DProxy::Instance()->FunctionCall("getNodeParamf", r, (int)node, param);
		return r;
	}


	DLL bool setNodeParamf( NodeHandle node, int param, float value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeParamf(node, param, value);
		Horde3DProxy::Instance()->FunctionCall("setNodeParamf", r, (int)node, param, value);
		return r;
	}


	DLL int getNodeParami( NodeHandle node, int param )
	{
		int r = Horde3DProxy::InitializedInstance()->GetNodeParami(node, param);
		Horde3DProxy::Instance()->FunctionCall("getNodeParami", r, (int)node, param);
		return r;
	}


	DLL bool setNodeParami( NodeHandle node, int param, int value )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeParami(node, param, value);
		Horde3DProxy::Instance()->FunctionCall("setNodeParami", r, (int)node, param, value);
		return r;
	}


	DLL const char *getNodeParamstr( NodeHandle node, int param )
	{
		const char* r = Horde3DProxy::InitializedInstance()->GetNodeParamstr(node, param);
		Horde3DProxy::Instance()->FunctionCall("getNodeParamstr", gcnew String(r), (int)node, param);
		return r;
	}


	DLL bool setNodeParamstr( NodeHandle node, int param, const char *name )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetNodeParamstr(node, param, name);
		Horde3DProxy::Instance()->FunctionCall("setNodeParamstr", r, (int)node, param, gcnew String(name));
		return r;
	}


	DLL bool getNodeAABB( NodeHandle node, float *minX, float *minY, float *minZ,
		float *maxX, float *maxY, float *maxZ )
	{
		bool r = Horde3DProxy::InitializedInstance()->GetNodeAABB(node, minX, minY, minZ, maxX, maxY, maxZ);
		Horde3DProxy::Instance()->FunctionCall("getNodeAABB", r, (int)node, *minX, *minY, *minZ, *maxX, *maxY, *maxZ);
		return r;
	}


	DLL int findNodes( NodeHandle startNode, const char *name, int type )
	{
		int r = Horde3DProxy::InitializedInstance()->FindNodes(startNode, name, type);
		Horde3DProxy::Instance()->FunctionCall("findNodes", r, (int)startNode, gcnew String(name), type);
		return r;
	}


	DLL NodeHandle getNodeFindResult( int index )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->GetNodeFindResult(index);
		Horde3DProxy::Instance()->FunctionCall("getNodeFindResult", (int)r, index);
		return r;
	}


	DLL NodeHandle castRay( NodeHandle node, float ox, float oy, float oz, float dx, float dy, float dz, int numNearest )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->CastRay(node, ox, oy, oz, dx, dy, dz, numNearest);
		Horde3DProxy::Instance()->FunctionCall("castRay", (int)r, (int)node, ox, oy, oz, dx, dy, dz, numNearest);
		return r;
	}


	DLL bool getCastRayResult( int index, NodeHandle *node, float *distance, float *intersection )
	{
		bool r = Horde3DProxy::InitializedInstance()->GetCastRayResult(index, node, distance, intersection);
		Horde3DProxy::Instance()->FunctionCall("getCastRayResult", r, index, (int)*node, *distance, *intersection);
		return r;
	}


	DLL NodeHandle addGroupNode( NodeHandle parent, const char *name )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddGroupNode(parent, name);
		Horde3DProxy::Instance()->FunctionCall("addGroupNode", (int)r, (int)parent, gcnew String(name));
		return r;
	}


	DLL NodeHandle addModelNode( NodeHandle parent, const char *name, ResHandle geometryRes )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddModelNode(parent, name, geometryRes);
		Horde3DProxy::Instance()->FunctionCall("addModelNode", (int)r, (int)parent, gcnew String(name), (int)geometryRes);
		return r;
	}


	DLL bool setupModelAnimStage( NodeHandle modelNode, int stage, ResHandle animationRes,
		const char *startNode, bool additive )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetupModelAnimStage(modelNode, stage, animationRes, startNode, additive);
		Horde3DProxy::Instance()->FunctionCall("setupModelAnimStage", r, (int)modelNode, stage, (int)animationRes, 
			gcnew String(startNode), additive);
		return r;
	}


	DLL bool setModelAnimParams( NodeHandle modelNode, int stage, float time, float weight )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetModelAnimParams(modelNode, stage, time, weight);
		Horde3DProxy::Instance()->FunctionCall("setModelAnimParams", r, (int)modelNode, stage, time, weight);
		return r;
	}


	DLL bool setModelMorpher( NodeHandle modelNode, const char *target, float weight )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetModelMorpher(modelNode, target, weight);
		Horde3DProxy::Instance()->FunctionCall("setModelMorpher", (int)modelNode, gcnew String(target), weight);
		return r;
	}


	DLL NodeHandle addMeshNode( NodeHandle parent, const char *name, ResHandle materialRes,
		int batchStart, int batchCount, int vertRStart, int vertREnd )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddMeshNode(parent, name, materialRes, batchStart, batchCount, vertRStart, vertREnd);
		Horde3DProxy::Instance()->FunctionCall("addMeshNode", (int)r, (int)parent, gcnew String(name),
			(int)materialRes, batchStart, batchCount, vertREnd, vertREnd);
		return r;
	}


	DLL NodeHandle addJointNode( NodeHandle parent, const char *name, int jointIndex )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddJointNode(parent, name, jointIndex);
		Horde3DProxy::Instance()->FunctionCall("addJointNode", (int)r, (int)parent, gcnew String(name), jointIndex);
		return r;
	}


	DLL NodeHandle addLightNode( NodeHandle parent, const char *name, ResHandle materialRes,
		const char *lightingContext, const char *shadowContext )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddLightNode(parent, name, materialRes, lightingContext, shadowContext);
		Horde3DProxy::Instance()->FunctionCall("addLightNode", (int)r, (int)parent, gcnew String(name),
			(int)materialRes, gcnew String(lightingContext), gcnew String(shadowContext));
		return r;
	}


	DLL bool setLightContexts( NodeHandle lightNode, const char *lightingContext, const char *shadowContext )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetLightContexts(lightNode, lightingContext, shadowContext);
		Horde3DProxy::Instance()->FunctionCall("setLightContexts", r, (int)lightNode, 
			gcnew String(lightingContext), gcnew String(shadowContext));
		return r;
	}


	DLL NodeHandle addCameraNode( NodeHandle parent, const char *name, ResHandle pipelineRes )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddCameraNode(parent, name, pipelineRes);
		Horde3DProxy::Instance()->FunctionCall("addCameraNode", (int)r, (int)parent, gcnew String(name), (int)pipelineRes);
		return r;
	}


	DLL bool setupCameraView( NodeHandle cameraNode, float fov, float aspect, float nearDist, float farDist )
	{
		bool r = Horde3DProxy::InitializedInstance()->SetupCameraView(cameraNode, fov, aspect, nearDist, farDist);
		Horde3DProxy::Instance()->FunctionCall("setupCameraView", r, (int)cameraNode, fov, aspect, nearDist, farDist);
		return r;
	}


	DLL bool calcCameraProjectionMatrix( NodeHandle cameraNode, float *projMat )
	{
		bool r = Horde3DProxy::InitializedInstance()->CalcCameraProjectionMatrix(cameraNode, projMat);
		Horde3DProxy::Instance()->FunctionCall("calcCameraProjectionMatrix", r, (int)cameraNode, nullptr);
		return r;
	}


	DLL NodeHandle addEmitterNode( NodeHandle parent, const char *name, ResHandle materialRes,
		ResHandle effectRes, int maxParticleCount, int respawnCount )
	{
		NodeHandle r = Horde3DProxy::InitializedInstance()->AddEmitterNode(parent, name, materialRes, effectRes, maxParticleCount, respawnCount);
		Horde3DProxy::Instance()->FunctionCall("addEmitterNode", (int)r, (int)parent, gcnew String(name),
			(int)materialRes, (int)effectRes, maxParticleCount, respawnCount);
		return r;
	}


	DLL bool advanceEmitterTime( NodeHandle emitterNode, float timeDelta )
	{
		bool r = Horde3DProxy::InitializedInstance()->AdvanceEmitterTime(emitterNode, timeDelta);
		Horde3DProxy::Instance()->FunctionCall("advanceEmitterTime", r, (int)emitterNode, timeDelta);
		return r;
	}


	DLL bool hasEmitterFinished( NodeHandle emitterNode )
	{
		bool r = Horde3DProxy::InitializedInstance()->HasEmitterFinished(emitterNode);
		Horde3DProxy::Instance()->FunctionCall("hasEmitterFinished", r, (int)emitterNode);
		return r;
	}
}