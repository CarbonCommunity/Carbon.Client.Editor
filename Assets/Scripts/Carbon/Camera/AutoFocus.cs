using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Carbon
{
	public class AutoFocus : MonoBehaviour
	{
		public Camera Camera;
		public PostProcessVolume Volume;
		public LayerMask Mask;
		public Vector2 Offset;

		[Range(0.1f, 20f)]
		public float Lerp;

		[Range(0.1f, 5000f)]
		public float Distance;

		public float CurrentDistance;

		internal RaycastHit _hit;
		internal Ray _ray;
		internal DepthOfField _dof;

		public void Awake()
		{
			_dof = Volume.profile.GetSetting<DepthOfField>();
		}

		public void Update()
		{
			_ray = Camera.ViewportPointToRay(Offset);
			_dof.focusDistance.value = Mathf.Lerp(_dof.focusDistance.value, CurrentDistance, Time.deltaTime * Lerp);

			if (!Physics.Raycast(_ray, out _hit, Distance, Mask, QueryTriggerInteraction.Ignore))
			{
				CurrentDistance = Distance;
				return;
			}

			CurrentDistance = _hit.distance;
		}
	}
}
