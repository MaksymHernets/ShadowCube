using ShadowCube.Setting;
using ShadowCube.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube
{
	public class PanelScreen_Phone : OptionPanel
    {
        [SerializeField] private Text Text_SystemResolution;
        [SerializeField] private Text Text_RenderingResolution;

        [SerializeField] private SliderTextUI SliderTextScaleRender;
        [SerializeField] private SliderTextUI SliderTextMaxFps;
        [SerializeField] private SliderTextUI SliderTextView;
        [SerializeField] private Toggle Toggle_AutoRotate;

        [Inject] ScreenSetting screenSetting;

		private void Start()
		{
            Text_SystemResolution.text = screenSetting.GetSystemResolution();
            Text_RenderingResolution.text = screenSetting.GetRenderingResolution();

            SliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
            SliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;
            SliderTextScaleRender.Value = screenSetting.scaleRender;
            SliderTextScaleRender.slider.onValueChanged.AddListener(Slider_ScaleRender_Changed);
            screenSetting.ScaleRender += Update_ScaleRender;

            SliderTextMaxFps.slider.onValueChanged.AddListener(SliderFPS_Changed);
            SliderTextMaxFps.slider.minValue = screenSetting.MinFPS;
            SliderTextMaxFps.slider.maxValue = screenSetting.MaxMaxFPS;
            SliderTextMaxFps.Value = screenSetting.maxFPS;
            screenSetting.MaxFPS += Event_MaxFps_Change;

            SliderTextView.slider.onValueChanged.AddListener(SliderView_Changed);
            SliderTextView.slider.minValue = screenSetting.MinViewCamera;
            SliderTextView.slider.maxValue = screenSetting.MaxViewCamera;
            SliderTextView.Value = screenSetting.fieldOfView;
            screenSetting.FieldOfView += Event_FieldOfViev_Change;

            Toggle_AutoRotate.isOn = screenSetting.autoRotate;
            Toggle_AutoRotate.onValueChanged.AddListener(Toggle_AutoRotate_Changed);
        }

		public void Slider_ScaleRender_Changed(float index)
        {
            screenSetting.scaleRender = index;
        }

        private void Update_ScaleRender(float scale)
		{
            Text_SystemResolution.text = screenSetting.GetSystemResolution();
            StartCoroutine(Update_RenderingResolution());
        }

		private IEnumerator Update_RenderingResolution()
		{
            yield return new WaitForSeconds(0.5f);
            Text_RenderingResolution.text = screenSetting.GetRenderingResolution();
        }

		private void Event_FieldOfViev_Change(int value)
        {
            SliderTextView.Value = value;
        }

        public void SliderFPS_Changed(float index)
        {
            screenSetting.maxFPS = (int)index;
        }

        public void SliderView_Changed(float index)
        {
            screenSetting.fieldOfView = (int)index;
        }

        private void Event_MaxFps_Change(int value)
        {
            SliderTextMaxFps.Value = value;
        }

        public void Toggle_AutoRotate_Changed(bool value)
        {
            screenSetting.autoRotate = value;
        }

        public override void SetupDefaultOption()
		{
			screenSetting.SetupDefaultSetting();
		}
	}
}
