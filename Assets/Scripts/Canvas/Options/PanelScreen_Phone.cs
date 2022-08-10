using ShadowCube.Setting;
using ShadowCube.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube
{
	public class PanelScreen_Phone : OptionPanel
    {
        [SerializeField] private SliderTextUI sliderTextScaleRender;
        [SerializeField] private Toggle toggle_AutoRotate;

        [SerializeField] private Text text_SystemResolution;
        [SerializeField] private Text text_RenderingResolution;

        [Inject] ScreenSetting screenSetting;

		private void Start()
		{
            sliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
            sliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;
            sliderTextScaleRender.Value = screenSetting.scaleRender;
            sliderTextScaleRender.slider.onValueChanged.AddListener(Slider_ScaleRender_Changed);

            toggle_AutoRotate.isOn = screenSetting.autoRotate;
            toggle_AutoRotate.onValueChanged.AddListener(Toggle_AutoRotate_Changed);

            screenSetting.ScaleRender += Update_ScaleRender;

            text_SystemResolution.text = screenSetting.GetSystemResolution();
            text_RenderingResolution.text = screenSetting.GetRenderingResolution();
        }

		public void Slider_ScaleRender_Changed(float index)
        {
            screenSetting.scaleRender = index;
        }

        private void Update_ScaleRender(float scale)
		{
            text_SystemResolution.text = screenSetting.GetSystemResolution();
            text_RenderingResolution.text = screenSetting.GetRenderingResolution();
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
