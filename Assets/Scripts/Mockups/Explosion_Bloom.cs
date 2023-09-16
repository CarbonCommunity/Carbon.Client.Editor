using UnityEngine;

public class Explosion_Bloom : MonoBehaviour
{
	public int m_Threshold;
	public int m_Curve;
	public int m_PrefilterOffs;
	public int m_SampleScale;
	public int m_Intensity;
	public int m_BaseTex;

	public class Settings : MonoBehaviour
	{
		public float thresholdGamma;
		public float thresholdLinear;
	}

}