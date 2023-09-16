using UnityEngine;

public class PipeMesh : MonoBehaviour
{
	public float PipeRadius;
	public float StraightLength;
	public int PipeSubdivisions;
	public int BendTesselation;
	public float RidgeHeight;
	public float UvScaleMultiplier;
	public float RidgeIncrements;
	public float RidgeLength;
	public UnityEngine.Vector2 HorizontalUvRange;
	public UnityEngine.Vector3 startDir;
	public UnityEngine.Vector3 endDir;
	public bool isBuilding;

	public class TesselatedLinePoint : MonoBehaviour
	{
	}

	public class UvType : MonoBehaviour
	{
	}

	public class GeneratePipeMesh : MonoBehaviour
	{
		public float PipeRadius;
		public UnityEngine.Vector3 StartDir;
		public UnityEngine.Vector3 EndDir;
		public float StraightLength;
		public int BendTesselation;
		public int PipeSubdivisions;
		public float UvScaleMultiplier;
		public float RidgeIncrements;
		public float RidgeHeight;
		public float RidgeLength;
		public int vertIndex;
		public int triIndex;
		public float pipeDist;
		public UnityEngine.Vector3 lastCentrePos;
		public int progressIndex;
		public float subDivDegrees;
	}

}