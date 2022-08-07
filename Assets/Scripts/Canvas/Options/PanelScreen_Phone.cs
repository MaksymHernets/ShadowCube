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

        [Inject] ScreenSetting screenSetting;

		private void Start()
		{
            sliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
            sliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;
            sliderTextScaleRender.Value = screenSetting.scaleRender;
            sliderTextScaleRender.slider.onValueChanged.AddListener(Slider_ScaleRender_Changed);

            toggle_AutoRotate.isOn = screenSetting.autoRotate;
            toggle_AutoRotate.onValueChanged.AddListener(Toggle_AutoRotate_Changed);
        }

		public void Slider_ScaleRender_Changed(float index)
        {
            screenSetting.scaleRender = index;
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
