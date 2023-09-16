using UnityEngine;

public class BossFormController : MonoBehaviour
{
	public float animationSpeed;
	public UnityEngine.Vector2 roamDistance;
	public float health;
	public int currentFrame;
	public int animDirection;
	public bool authorative;
	public UnityEngine.Vector3 heading;
	public UnityEngine.Vector3 positionLocal;
	public UnityEngine.Vector3 positionWorld;

	public class BossDamagePoint : MonoBehaviour
	{
		public float health;
		public bool destroyed;
	}

}