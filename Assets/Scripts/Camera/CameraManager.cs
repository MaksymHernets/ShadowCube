using ShadowCube.Setting;
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Zenject;

namespace ShadowCube
{
	public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
		[SerializeField] private PostProcessVolume postProcessVolume;

		[Inject] GraphicSetting graphicSetting;

		private void Start()
		{
			mainCamera.fieldOfView = graphicSetting.fieldOfView;
			postProcessVolume.enabled = Convert.ToBoolean(graphicSetting.screenEffect);

			graphicSetting.FieldOfView += value => mainCamera.fieldOfView = value;
			graphicSetting.ScreenEffect += value => postProcessVolume.enabled = Convert.ToBoolean(value);
		}
	}
}
