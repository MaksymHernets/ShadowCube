using ShadowCube.Setting;
using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;


namespace ShadowCube
{
	public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
		[SerializeField] private UniversalAdditionalCameraData postProcessVolume;

		[Inject] GraphicSetting graphicSetting;

		private void Start()
		{
			mainCamera.fieldOfView = graphicSetting.fieldOfView;
			postProcessVolume.renderPostProcessing = Convert.ToBoolean(graphicSetting.screenEffect);

			graphicSetting.FieldOfView += value => mainCamera.fieldOfView = value;
			graphicSetting.ScreenEffect += value => postProcessVolume.renderPostProcessing = Convert.ToBoolean(value);
		}
	}
}
