using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestImg : MonoBehaviour
{
	public RawImage Img;
	public Texture2D Tex;

	public void Start()
	{
		var scale = 4;
		var width = (int)(Screen.width) * scale;
		var height = (int)(Screen.height) * scale;

		var mapCamera = new GameObject().AddComponent<Camera>();
		var light = mapCamera.gameObject.AddComponent<Light>();
		light.shadows = LightShadows.None;
		light.type = LightType.Directional;
		mapCamera.cullingMask = LayerMask.GetMask("Terrain", "Construction");
		mapCamera.clearFlags = CameraClearFlags.Nothing;
		mapCamera.orthographic = true;
		mapCamera.orthographicSize = 3000;
		mapCamera.renderingPath = RenderingPath.Forward;
		mapCamera.farClipPlane = 5000;
		mapCamera.nearClipPlane = 0.1f;
		mapCamera.transform.SetPositionAndRotation(new Vector3(1175, 20, 1175), Quaternion.Euler(90, 0, 0));
		var renderTexture2 = new RenderTexture(width, height, 1024);
		mapCamera.targetTexture = renderTexture2;

		var shot = new Texture2D(width, height, TextureFormat.RGB565, transform);
		mapCamera.Render();

		RenderTexture.active = renderTexture2;
		shot.ReadPixels(new Rect(0, 0, width, height), 0, 0, true);

		mapCamera.targetTexture = null;
		RenderTexture.active = null;
		Destroy(mapCamera.gameObject);
		Destroy(renderTexture2);

		Img.texture = Tex = shot;

		Debug.Log("did done it");
	}
}
