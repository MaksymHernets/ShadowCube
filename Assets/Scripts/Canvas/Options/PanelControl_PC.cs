using ShadowCube.Setting;
using ShadowCube.UI;
using UniRx;
using UnityEngine;
using Zenject;

public class PanelControl_PC : OptionPanel
{
    [Header("Control")]
    [SerializeField] private SliderTextUI sliderTextMouse;

    [Inject] ControlSetting controlSetting;

	private void Start()
	{
        sliderTextMouse.Value = controlSetting.speedMouse;
        sliderTextMouse.slider.onValueChanged.AddListener(SliderMouse_Changed);

        controlSetting.SpeedMouse.Subscribe(Observer.Create<float>(value => sliderTextMouse.Value = value));
    }

	public void SliderMouse_Changed(float value)
    {
        controlSetting.speedMouse = value;
    }

	public override void SetupDefaultOption()
	{
        controlSetting.SetupDefaultSetting();
    }
}
