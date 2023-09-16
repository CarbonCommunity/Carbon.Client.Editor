using UnityEngine;

public class ScreenshotCamera : MonoBehaviour
{
	public float skyLightColorMultiplier;
	public float skyLightColorMultiplierOcean;
	public float sunRayColorMultiplier;
	public float sunRayColorMultiplierOcean;
	public float moonRayColorMultiplier;
	public float moonRayColorMultiplierOcean;
	public float sunMeshBrightness;
	public float sunMeshBrightnessMultiplier;
	public float sunMeshBrightnessMultiplierOcean;
	public float moonMeshBrightness;
	public float moonMeshBrightnessMultiplier;
	public float moonMeshBrightnessMultiplierOcean;
	public float atmosphereBrightnessMultiplier;
	public float atmosphereBrightnessMultiplierOcean;
	public float directionalLightDay;
	public float directionalLightNight;
	public float directionalLightMultiplier;
	public float directionalLightMultiplierOcean;
	public float ambientLightDay;
	public float ambientLightNight;
	public float ambientLightMultiplier;
	public float ambientLightMultiplierTarget;
	public float ambientLightMultiplierOcean;
	public float skyReflectionDay;
	public float skyReflectionNight;
	public float skyReflectionMultiplier;
	public float skyReflectionMultiplierTarget;
	public float skyReflectionMultiplierOcean;
	public bool isMoving;
	public bool isRotating;
	public float loadingScreenVisibleTime;
	public float environmentTimestamp;
	public float environmentTransitionSpeed;
	public int screenWidth;
	public int screenHeight;
	public UnityEngine.Vector3 lastPosition;
	public float lastDOFUpdateTime;
	public bool updateSkyParameters;
	public bool wasJustLoading;
	public float ActualDeptOfFieldFocalLength;

}