using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
using UnityEngine;

public class Defines : MonoBehaviour
{
	[Header("Debugger")]
	public ColorSwitch[] ColorSwitches;
	public ColorSwitch InvalidSwitch;
	public ColorSwitch BlankSwitch;

	[Serializable]
	public class ColorSwitch
	{
		[Header("Properties")]
		public string Tag;
		public bool Enabled = true;

		[Header("Colors")]
		public Color Main = Color.white;
		public Color Outline = Color.white;
	}

	public static Defines Singleton { get; private set; }

	public Defines()
	{
		Singleton = this;
	}

	public ColorSwitch GetSwitch(int index)
	{
		if (index > ColorSwitches.Length - 1 || index < 0)
		{
			return InvalidSwitch;
		}

		var result = ColorSwitches[index];

		if (!result.Enabled)
		{
			return BlankSwitch;
		}

		return result;
	}

	public static string Root => Path.GetFullPath(Path.Combine(Application.dataPath, ".."));

	public static string GetBundleDirectory()
	{
		var folder = Path.GetFullPath(Path.Combine(Root, "Addons"));

		if (!Directory.Exists(folder))
		{
			Directory.CreateDirectory(folder);
		}

		return folder;
	}

	public static string GetBundleDirectory(AddonEditor forAddon)
	{
		var folder = Path.Combine(GetBundleDirectory(), $"{forAddon.name}_{forAddon.Version}");

		if (!Directory.Exists(folder))
		{
			Directory.CreateDirectory(folder);
		}

		return folder;
	}
}
