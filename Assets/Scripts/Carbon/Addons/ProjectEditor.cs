using System.IO;
using System.Net;
using UnityEngine;

namespace Carbon
{
	public class Project : MonoBehaviour
	{
		public static Project Current { get; private set; }

		public Project()
		{
			Current = this;
		}

		public AddonEditor Editor;

#if UNITY_EDITOR
		[UnityEditor.MenuItem("Carbon/Update Carbon")]
		public static void UpdateCarbonAssets()
		{
			using (var client = new WebClient())
			{
				File.WriteAllText(Path.Combine(Defines.Root, "Assets", "Scripts", "Carbon", "Source", "Addon.cs"),
					client.DownloadString("https://raw.githubusercontent.com/CarbonCommunity/Carbon.Common.Client/develop/src/Assets/Addon.cs"));

				File.WriteAllText(Path.Combine(Defines.Root, "Assets", "Scripts", "Carbon", "Source", "Asset.cs"),
					client.DownloadString("https://raw.githubusercontent.com/CarbonCommunity/Carbon.Common.Client/develop/src/Assets/Asset.cs"));

				File.WriteAllText(Path.Combine(Defines.Root, "Assets", "Scripts", "Carbon", "Source", "RustComponent.cs"),
					client.DownloadString("https://raw.githubusercontent.com/CarbonCommunity/Carbon.Common.Client/develop/src/Assets/RustComponent.cs"));

				File.WriteAllText(Path.Combine(Defines.Root, "Assets", "Scripts", "Carbon", "Source", "RustPrefab.cs"),
					client.DownloadString("https://raw.githubusercontent.com/CarbonCommunity/Carbon.Common.Client/develop/src/Assets/RustPrefab.cs"));

				File.WriteAllText(Path.Combine(Defines.Root, "Assets", "Scripts", "Carbon", "Source", "Client.Protocol.cs"),
					client.DownloadString("https://raw.githubusercontent.com/CarbonCommunity/Carbon.Common/develop/src/Carbon/Components/Client.Protocol.cs"));
			}
		}
#endif
	}
}
