using UnityEngine;

public class DeferredMeshDecal : MonoBehaviour
{
	public bool isVisible;

	public class MaterialReplacement : MonoBehaviour
	{
		public int refCount;
	}

	public class MaterialLink : MonoBehaviour
	{
		public int submeshIndex;
	}

	public class InstanceData : MonoBehaviour
	{
		public int submeshIndex;
		public int hash;
		public int SubmeshIndex;
	}

}