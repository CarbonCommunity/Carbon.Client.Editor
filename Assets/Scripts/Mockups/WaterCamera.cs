using UnityEngine;

public class WaterCamera : MonoBehaviour
{
	public int _PreviousVP;
	public int _NonJitteredVP;
	public int _CausticsTex;
	public int _CausticsSpeed;
	public int _CausticsScale;
	public int _CausticsBrightness;
	public int _WaterCaustics_LightDirection;
	public int _Water_CameraView;
	public int _Water_CameraViewProj;
	public int _WaterSSR_CameraProj;
	public int _Water_CameraInvViewProj;
	public int _FrustumNearCorners;
	public int _FrustumRayCorners;
	public int _WaterSSR_WorldNormTexture;
	public int _WaterSSR_ReflectionTexture;
	public int _WaterSurfaceTexture;
	public int _WaterSurfaceMaskTexture;
	public int _WaterPreFogBackgroundTexture;
	public int _WaterMotionTexture;
	public int _Water_CullingVolumeArray;
	public int _Water_CullingVolumeCount;
	public int _BackgroundColorTexture;
	public int _WorldSpaceLightPos0;
	public int _LightColor0;
	public int width;
	public int height;
	public int visibilityMask;
	public bool initializedMaterials;
	public int occlusionPassId;
	public int depthNormalsPassId;
	public int motionPassId;

}