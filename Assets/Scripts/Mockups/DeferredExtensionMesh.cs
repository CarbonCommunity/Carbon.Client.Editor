using UnityEngine;

public class DeferredExtensionMesh : MonoBehaviour
{
	public bool isVisible;

	public class MaterialLink : MonoBehaviour
	{
		public int submeshIndex;
		public int passIndex;
	}

}