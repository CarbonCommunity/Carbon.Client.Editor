using UnityEngine;

public class VolumetricDustParticles : MonoBehaviour
{
	public float alpha;
	public float size;
	public float speed;
	public float density;
	public float spawnMaxDistance;
	public bool cullingEnabled;
	public float cullingMaxDistance;
	public bool particlesAreInstantiated;
	public int particlesCurrentCount;
	public int particlesMaxCount;

	public class Direction : MonoBehaviour
	{
	}

}