using UnityEngine;

public class GenerateDungeonBase : MonoBehaviour
{
	public bool RunOnCache;

	public class DungeonSegment : MonoBehaviour
	{
		public UnityEngine.Vector3 position;
		public int score;
		public int cost;
		public int floor;
	}

}