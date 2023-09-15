using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Carbon;
using ProtoBuf;
using UnityEngine;

public class Defines : MonoBehaviour
{
	public float InfoDistance;
	public bool DisableAll;

	[Header("Debugger")]
	public ColorSwitch InvalidSwitch;
	public ColorSwitch BlankSwitch;

	public static Defines Singleton { get; private set; }

	public Defines()
	{
		Singleton = this;
	}

	public ColorSwitch GetSwitch(ColorSwitch @switch)
	{
		if(@switch == null)
		{
			return InvalidSwitch;
		}

		if (!@switch.Enabled || DisableAll)
		{
			return BlankSwitch;
		}

		return @switch;
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
