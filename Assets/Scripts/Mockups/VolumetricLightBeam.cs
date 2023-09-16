using UnityEngine;

public class VolumetricLightBeam : MonoBehaviour
{
	public bool colorFromLight;
	public float alphaInside;
	public float alphaOutside;
	public bool spotAngleFromLight;
	public float spotAngle;
	public float coneRadiusStart;
	public int geomCustomSides;
	public int geomCustomSegments;
	public bool geomCap;
	public bool fadeEndFromLight;
	public float attenuationCustomBlending;
	public float fadeStart;
	public float fadeEnd;
	public float depthBlendDistance;
	public float cameraClippingDistance;
	public float glareFrontal;
	public float glareBehind;
	public float boostDistanceInside;
	public float fresnelPowInside;
	public float fresnelPow;
	public bool noiseEnabled;
	public float noiseIntensity;
	public bool noiseScaleUseGlobal;
	public float noiseScaleLocal;
	public bool noiseVelocityUseGlobal;
	public UnityEngine.Vector3 noiseVelocityLocal;
	public int pluginVersion;
	public bool _TrackChangesDuringPlaytime;
	public int _SortingLayerID;
	public int _SortingOrder;
	public float coneAngle;
	public float coneRadiusEnd;
	public float coneVolume;
	public float coneApexOffsetZ;
	public int geomSides;
	public int geomSegments;
	public float attenuationLerpLinearQuad;
	public int sortingLayerID;
	public int sortingOrder;
	public bool trackChangesDuringPlaytime;
	public bool isCurrentlyTrackingChanges;
	public bool hasGeometry;
	public UnityEngine.Bounds bounds;
	public int blendingModeAsInt;
	public int meshVerticesCount;
	public int meshTrianglesCount;

}