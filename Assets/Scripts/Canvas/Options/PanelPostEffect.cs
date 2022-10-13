using ShadowCube.Setting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube
{
	public class PanelPostEffect : OptionPanel
    {
        [SerializeField] private Toggle Toggle_PostEffect;
        [SerializeField] private Toggle Toggle_Bloom;
        [SerializeField] private Toggle Toggle_Focus;

        [Inject] GraphicSetting graphicSetting;
        [Inject] ScreenSetting screenSetting;

        private void Start()
		{
            Toggle_PostEffect.isOn = screenSetting.postEffect;
            Toggle_PostEffect.onValueChanged.AddListener(Toggle_PostEffect_Changed);

            Toggle_Bloom.isOn = screenSetting.postEffect;
            Toggle_Bloom.onValueChanged.AddListener(Toggle_Bloom_Changed);

            Toggle_Focus.isOn = screenSetting.postEffect;
            Toggle_Focus.onValueChanged.AddListener(Toggle_Focus_Changed);
		}

        public void Toggle_PostEffect_Changed(bool value)
        {
            screenSetting.postEffect = value;
        }

        public void Toggle_Bloom_Changed(bool value)
        {
            //screenSetting.postEffect = value;
        }

        public void Toggle_Focus_Changed(bool value)
        {
            //screenSetting.postEffect = value;
        }
    }
}
