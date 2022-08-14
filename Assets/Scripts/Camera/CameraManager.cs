using ShadowCube.Setting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;


namespace ShadowCube
{
	public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
		[SerializeField] private UniversalAdditionalCameraData postProcessVolume;

		[Inject] ScreenSetting screenSetting;

		private void Start()
		{
			mainCamera.fieldOfView = screenSetting.fieldOfView;
			postProcessVolume.renderPostProcessing = screenSetting.postEffect;

			screenSetting.FieldOfView += value => mainCamera.fieldOfView = value;
			screenSetting.PostEffect += value => postProcessVolume.renderPostProcessing = value;
		}
	}
}
