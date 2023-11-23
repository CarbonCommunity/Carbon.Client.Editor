using System.Linq;
using Carbon.Client;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace Carbon
{
	[ExecuteAlways]
    public class Info : MonoBehaviour
    {
		public Text ProjectText;
		public Text VideoText;
		public Text AudioText;

		public void Update()
		{
			try
			{
				HandleProject();
			}
			catch
			{
				ProjectText.text = "[Fail]";
			}
			try
			{
				HandleVideo();
			}
			catch
			{
				VideoText.text = "[Fail]";
			}
			try
			{
				HandleAudio();
			}
			catch
			{
				AudioText.text = "[Fail]";
			}
		}

		internal void HandleProject()
		{
			var selectionInfo = "N/A";
			var selectionScene = string.Empty;

#if UNITY_EDITOR
			if (Selection.activeGameObject != null)
			{
				selectionInfo = CarbonUtils.GetRecursiveName(Selection.activeGameObject.transform);

				var scene = Selection.activeGameObject.gameObject.scene.name;
				selectionScene = string.IsNullOrEmpty(scene) ? string.Empty : $"[{Selection.activeGameObject.gameObject.scene.name}]";
			}
#endif

			var editor = Project.Current?.Editor;
			var prefabs = editor?.Scene.Prefabs.Count + editor?.Models.Prefabs.Count;
			var rustPrefabs = editor?.Scene.RustPrefabs.Count + editor?.Models.RustPrefabs.Count;

			var playerCamera = FirstPersonController.Instance?.playerCamera;

			ProjectText.text = $"\n{(editor == null ? "N/A" : $"{editor?.Name} [{editor?.name}]")}" +
				$"\n{(editor == null ? "N/A" : $"{prefabs:n0} prbs./{rustPrefabs:n0} rust prbs.]")}" +
				$"\n{selectionInfo} {selectionScene}" +
				$"\n{playerCamera?.transform.position.x:0.00}, {playerCamera?.transform.position.y:0.00}, {playerCamera?.transform.position.z:0.00}";
		}
		internal void HandleVideo()
		{
			var quality = string.Empty;

			switch (QualitySettings.masterTextureLimit)
			{
				case 0: quality = "Full Res."; break;
				case 1: quality = "Half Res"; break;
				case 2: quality = "Quarter Res"; break;
				case 3: quality = "Eighth Res"; break;
			}

			VideoText.text = $"\n{SystemInfo.graphicsDeviceName} [{QualitySettings.names[QualitySettings.GetQualityLevel()]}]" +
				$"\n{quality} [{QualitySettings.masterTextureLimit}/{(QualitySettings.softParticles ? "soft part." : "hard part.")}/{(QualitySettings.softVegetation ? "soft vege." : "hard vege.")}]" +
				$"\n{QualitySettings.shadowDistance} dist. [{QualitySettings.shadows}/{QualitySettings.shadowCascades} casc.]" +
				$"\n{QualitySettings.vSyncCount}";
		}
		internal void HandleAudio()
		{
			AudioText.text = $"\n{AudioListener.volume:0.0} [{(AudioListener.pause ? "PAUSED" : "PLAYING")}]" +
				$"\n{AudioSettings.speakerMode}";
		}
	}
}
