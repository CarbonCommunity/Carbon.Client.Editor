using UnityEngine;

public class PhoneController : MonoBehaviour
{
	public int PhoneNumber;
	public bool CanModifyPhoneName;
	public bool CanSaveNumbers;
	public bool RequirePower;
	public bool RequireParent;
	public float CallWaitingTime;
	public bool AppendGridToName;
	public bool IsMobile;
	public bool CanSaveVoicemail;
	public float RingingLightFrequency;
	public float callStartTime;
	public int voicemailTarget;
	public int requestedDialNumber;
	public bool cachedCanLeaveVoicemail;
	public int MaxVoicemailSlots;
	public bool isServer;
	public float CallDuration;
	public bool IsDead;

}