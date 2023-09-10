using UnityEngine;

namespace Carbon.Client
{
	public class CarbonUtils
	{
		public static string GetRecursiveName(Transform transform, string strEndName = "")
		{
			var text = transform.name;

			if (!string.IsNullOrEmpty(strEndName))
			{
				text = text + "/" + strEndName;
			}

			if (transform.parent != null)
			{
				text = GetRecursiveName(transform.parent, text);
			}

			return text;
		}
	}
}
