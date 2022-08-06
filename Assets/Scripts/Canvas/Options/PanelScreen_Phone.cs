using ShadowCube.Setting;
using ShadowCube.UI;
using UnityEngine;
using Zenject;

namespace ShadowCube
{
	public class PanelScreen_Phone : OptionPanel
    {
        [SerializeField] private SliderTextUI sliderTextScaleRender;

        [Inject] ScreenSetting screenSetting;

		private void Start()
		{
            sliderTextScaleRender.Value = screenSetting.scaleRender;
            sliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
            sliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;
            sliderTextScaleRender.slider.onValueChanged.AddListener(SliderScaleRender_Changed);
        }

		public void SliderScaleRender_Changed(float index)
        {
            screenSetting.scaleRender = index;
        }

		public override void SetupDefaultOption()
		{
			screenSetting.SetupDefaultSetting();
		}
	}
}
