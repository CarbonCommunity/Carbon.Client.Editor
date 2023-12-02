using UnityEngine;

[ExecuteAlways]
public class Grid : MonoBehaviour
{
	public float Spacing;
	public int PerRow;
	public float Height;

	[ContextMenu("Apply")]
	public void Apply()
	{
		var count = 0;
		var row = 0;

		foreach(Transform child in transform)
		{
			child.transform.position = transform.position + new Vector3(Spacing * row, Height, Spacing * count);

			count++;

			if(count >= PerRow)
			{
				row++;
				count = 0;
			}
		}
	}

	public void Update()
	{
		Apply();
	}
}
