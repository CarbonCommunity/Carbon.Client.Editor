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
	public ColorSwitch BoundsSwitch;
	public ColorSwitch InvalidSwitch;
	public ColorSwitch BlankSwitch;
	public GameObject RconEntityTemplate;

	public Transform RconEntityContainer;
	public Transform PreviewContainer;

	public Defines()
	{
		_instance = this;
	}

	public Transform GetPreviewContainer()
	{
		if (PreviewContainer == null && gameObject != null && gameObject.scene.IsValid())
		{
			PreviewContainer = new GameObject("Preview Container").transform;

			try
			{
				SceneManager.MoveGameObjectToScene(PreviewContainer.gameObject, gameObject.scene);
			}
			catch { }
		}

		return PreviewContainer;
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
		try
		{
			DestroyImmediate(Singleton.PreviewContainer.gameObject);
		}
		catch { }

		try
		{
			Destroy(Singleton.PreviewContainer.gameObject);
		}
		catch { }

		Singleton.PreviewContainer = null;
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

		#if UNITY_EDITOR
		AddonEditor.ResetEditor();
		#endif
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
