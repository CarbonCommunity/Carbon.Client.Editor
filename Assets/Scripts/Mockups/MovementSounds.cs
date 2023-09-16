using UnityEngine;

public class MovementSounds : MonoBehaviour
{
	public float waterMovementFadeInSpeed;
	public float waterMovementFadeOutSpeed;
	public bool inWater;
	public float waterLevel;
	public bool mute;
	public UnityEngine.Vector3 velocity;
	public int velocityReadings;
	public float movementYSmoothed;
	public bool wasInWater;
	public float lastTime;

}