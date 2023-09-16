using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Carbon;
using ProtoBuf;
using UnityEngine;

public class Defines : MonoBehaviour
{
	public static bool IsBuildingAddons;

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

	public static void OnPreAddonBuild()
	{
		IsBuildingAddons = true;

		Debug.Log($"[OnPreAddonBuild] Found {RustAsset.assets.Count:n0} Rust assets");

		foreach(var asset in RustAsset.assets)
		{
			asset.Cleanup();
		}
	}
	public static void OnPostAddonBuild()
	{
		IsBuildingAddons = false;
	}

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
