using UnityEngine;

public class Wearable : MonoBehaviour
{
	public bool IsBackpack;
	public bool showCensorshipCube;
	public bool showCensorshipCubeBreasts;
	public bool forceHideCensorshipBreasts;
	public bool disableRigStripping;
	public bool overrideDownLimit;
	public float downLimit;
	public bool HideInEyesView;
	public bool HideInFirstPerson;
	public float ExtraLeanBack;
	public bool PreserveBones;

	public class RemoveSkin : MonoBehaviour
	{
	}

	public class RemoveHair : MonoBehaviour
	{
	}

	public class DeformHair : MonoBehaviour
	{
	}

	public class OccupationSlots : MonoBehaviour
	{
	}

	public class PartRandomizer : MonoBehaviour
	{
	}

	public class PartCollection : MonoBehaviour
	{
	}

}