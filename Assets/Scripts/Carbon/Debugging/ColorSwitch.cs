using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Carbon
{
	[CreateAssetMenu(menuName = "Carbon/Debugging/Create Color Switch")]
    public class ColorSwitch : ScriptableObject
    {
		[Header("Properties")]
		public string Tag;
		public bool Enabled = true;

		[Header("Colors")]
		public Color Main = Color.white;
		public Color Outline = Color.white;
	}
}
