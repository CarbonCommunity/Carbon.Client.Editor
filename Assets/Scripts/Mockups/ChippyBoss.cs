using UnityEngine;

public class ChippyBoss : MonoBehaviour
{
	public UnityEngine.Vector2 roamDistance;
	public float animationSpeed;
	public float moveSpeed;
	public int bossLevel;
	public float fireRate;
	public int currentFrame;
	public int animDirection;
	public float nextBulletTime;
	public uint id;
	public uint spriteID;
	public uint soundID;
	public bool visible;
	public UnityEngine.Vector3 heading;
	public bool isEnabled;
	public bool dirty;
	public float alpha;
	public bool host;
	public bool localAuthorativeOverride;
	public uint prefabID;
	public bool takesDamage;
	public float health;
	public float maxHealth;
	public bool mapLoadedEntiy;
	public UnityEngine.Vector3 positionLocal;
	public UnityEngine.Vector3 positionWorld;

	public class BossDamagePoint : MonoBehaviour
	{
		public float health;
		public bool destroyed;
	}

}