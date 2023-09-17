using System.IO;
using System.Linq;
using Carbon;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defines : MonoBehaviour
{
	private static Defines _instance;
	public static Defines Singleton => _instance ?? (_instance = FindObjectOfType<Defines>());

	public static bool IsBuildingAddons;

	public float InfoDistance;
	public bool DisableAll;

	[Header("Debugger")]
	public ColorSwitch InvalidSwitch;
	public ColorSwitch BlankSwitch;

	public Transform PreviewHub;

	public Transform GetPreviewHub()
	{
		if (PreviewHub == null)
		{
			PreviewHub = new GameObject("Preview Hub").transform;
			SceneManager.MoveGameObjectToScene(PreviewHub.gameObject, gameObject.scene);
		}

		return PreviewHub;
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

	public static void OnReload() 
	{
		DestroyImmediate(Singleton.PreviewHub.gameObject);
		Singleton.PreviewHub = null;
	}
	public static void OnPreAddonBuild()
	{
		IsBuildingAddons = true;

		var assets = RustAsset.assets;
		Debug.Log($"[OnPreAddonBuild] Found {assets.Count():n0} Rust assets");

		foreach(var asset in assets)
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
