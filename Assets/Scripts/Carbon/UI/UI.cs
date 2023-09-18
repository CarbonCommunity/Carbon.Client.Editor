using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Carbon
{
    public class UI : MonoBehaviour
    {
		public Camera Camera;

		[Header("Loading")]
		public Text TitleLoadingText;
		public Text SubtitleLoadingText;
		public CanvasGroup LoadingGroup;

		[Header("Stages")]
		public Transform LoadingPivot;
		public Transform MenuPivot;

		internal bool _isLoading;

		internal static UI _instance;
		public static UI Singleton => _instance ?? (_instance = FindObjectOfType<UI>());

		public void Start()
		{
			SetLoadingInfo("Starting up", "Please wait...");

			StartCoroutine(RustAssetProcessor.Instance.Load());

			RustAssetProcessor.OnAssetsLoaded += prefabs =>
			{
				SetLoadingInfo(string.Empty, string.Empty);
				UIUtils.Transition(Camera.transform, MenuPivot.position, MenuPivot.rotation.eulerAngles, 2f);
			};

			EnableCamera(true);
		}

		public void SetLoadingInfo(string title, string subtitle)
		{
			if (!_isLoading)
			{
				UIUtils.Transition(Camera.transform, LoadingPivot.transform.position, LoadingPivot.transform.rotation.eulerAngles, 2f);
				_isLoading = true;
			}

			TitleLoadingText.text = title;
			SubtitleLoadingText.text = subtitle;
		}

		public void EnableCamera(bool wants)
		{
			Camera.gameObject.SetActive(wants);
		}
    }
}
