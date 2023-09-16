using UnityEngine;

public class RandomItemDispenser : MonoBehaviour
{
	public bool OnlyAwardOne;
	public UnityEngine.Vector3 worldPosition;
	public UnityEngine.Vector3 worldForward;
	public UnityEngine.Vector3 localPosition;
	public UnityEngine.Vector3 localScale;
	public uint prefabID;
	public int instanceID;
	public bool isServer;
	public bool isClient;

	public class RandomItemChance : MonoBehaviour
	{
		public int Amount;
		public float Chance;
	}

}