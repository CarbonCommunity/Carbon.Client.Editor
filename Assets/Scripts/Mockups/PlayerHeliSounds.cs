using UnityEngine;

public class PlayerHeliSounds : MonoBehaviour
{
	public float engineStartFadeOutTime;
	public float engineLoopFadeInTime;
	public float engineLoopFadeOutTime;
	public float engineStopFadeOutTime;
	public float rotorLoopFadeInTime;
	public float rotorLoopFadeOutTime;
	public float enginePitchInterpRate;
	public float rotorPitchInterpRate;
	public float rotorGainInterpRate;
	public float rotorStartStopPitchRateUp;
	public float rotorStartStopPitchRateDown;
	public float rotorStartStopGainRateUp;
	public float rotorStartStopGainRateDown;
	public float rotorStartStopPitchMult;
	public float rotorStartStopGainMult;
	public bool isOn;
	public bool wasOn;
	public bool isStartingUp;

	public class FlightSoundLayer : MonoBehaviour
	{
		public float fadeTime;
		public float initialGain;
		public float gainRateUp;
		public float gainRateDown;
		public float gainInterpRate;
		public float initialPitch;
		public float pitchRateUp;
		public float pitchRateDown;
		public float pitchInterpRate;
		public bool returnToInitialWhenTurnedOff;
		public bool useUpDotPitchCurve;
		public float startStopGain;
		public float startStopPitch;
	}

}