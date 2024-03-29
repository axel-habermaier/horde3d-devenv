[[FX]]

<Sampler id="albedoMap">
	<StageConfig addressMode="CLAMP" filtering="none" maxAnisotropy="2" />
</Sampler>

<Sampler id="testTexture" texUnit="4"/>

<Uniform id="modulate" a="1.0" b="0.5" c="0.2" d="0.4"/>

<Uniform id="data"/>

<Context id="ATTRIBPASS">
	<Shaders vertex="VS_GENERAL" fragment="FS_ATTRIBPASS" />
</Context>

<Context id="AMBIENT">
	<Shaders vertex="VS_GENERAL" fragment="FS_AMBIENT" />
	<RenderConfig writeDepth="False" blendMode="MULT" alphaTest="LESS" alphaRef="0.1" depthTest="GREATER_EQUAL" alphaToCoverage="True" />
</Context>


[[VS_GENERAL]]
// =================================================================================================

#include "shaders/utilityLib/vertCommon.glsl"

uniform vec3 viewer;
varying vec3 viewVec;

void main(void)
{
	vec4 pos = calcWorldPos( gl_Vertex );
	viewVec = pos.xyz - viewer;
	
	gl_Position = gl_ModelViewProjectionMatrix * pos;
}
				

[[FS_ATTRIBPASS]]
// =================================================================================================

#include "shaders/utilityLib/fragDeferredWrite.glsl"

uniform samplerCube albedoMap;
varying vec3 viewVec;

void main( void )
{
	vec3 albedo = textureCube( albedoMap, viewVec ).rgb;
	
	// Set fragment material ID to 2, meaning skybox in this case
	setMatID( 2.0 );
	setAlbedo( albedo );
}


[[FS_AMBIENT]]
// =================================================================================================

uniform samplerCube albedoMap;
uniform vec4 modulate;
varying vec3 viewVec;

void main( void )
{
	vec3 albedo = textureCube( albedoMap, viewVec ).rgb * modulate;
	
	gl_FragColor.rgb = albedo;
}