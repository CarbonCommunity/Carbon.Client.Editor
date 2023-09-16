using UnityEngine;

public class UIPaintableImage : MonoBehaviour
{
	public int texSize;
	public bool mipmaps;
	public int imageNumber;
	public uint imageHash;
	public bool isLocked;
	public bool isLoading;
	public bool isBlank;
	public bool needsApply;

	public class DrawMode : MonoBehaviour
	{
	}

}