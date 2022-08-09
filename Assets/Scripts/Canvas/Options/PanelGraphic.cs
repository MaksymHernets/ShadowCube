using ShadowCube.Setting;
using ShadowCube.UI;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelGraphic : OptionPanel
{
    [Header("Graphic")]
    [SerializeField] private Dropdown DropDownSync;
    [SerializeField] private SliderTextUI SliderTextMaxFps;
    [SerializeField] private SliderTextUI SliderTextView;
    [SerializeField] private Dropdown DropDownQuality;
    [SerializeField] private Dropdown DropDownEffect;
    [SerializeField] private Toggle ToggleShowFps;

    [Inject] GraphicSetting graphicSetting;

	private void Start()
	{
        DropDownSync.ClearOptions();
        DropDownSync.AddOptions( graphicSetting.GetNamesSync() );
        DropDownSync.onValueChanged.AddListener(DropdownSync_Changed);
        DropDownSync.value = graphicSetting.syncCount;
        
        SliderTextMaxFps.slider.onValueChanged.AddListener(SliderFPS_Changed);
        SliderTextMaxFps.slider.minValue = graphicSetting.MinFPS;
        SliderTextMaxFps.slider.maxValue = graphicSetting.MaxMaxFPS;
        SliderTextMaxFps.Value = graphicSetting.maxFPS;
        graphicSetting.MaxFPS += Event_MaxFps_Change;

        SliderTextView.slider.onValueChanged.AddListener(SliderView_Changed);
        SliderTextView.slider.minValue = graphicSetting.MinViewCamera;
        SliderTextView.slider.maxValue = graphicSetting.MaxViewCamera;
        SliderTextView.Value = graphicSetting.fieldOfView;
        graphicSetting.FieldOfView += Event_FieldOfViev_Change;

        DropDownQuality.ClearOptions();
        DropDownQuality.AddOptions(graphicSetting.GetNamesQualityLevel().ToList());
        DropDownQuality.onValueChanged.AddListener(DropdownQuality_Changed);
        DropDownQuality.value = graphicSetting.qualityLevel;

        DropDownEffect.ClearOptions();
        DropDownEffect.AddOptions(graphicSetting.GetNamesEffect().ToList());
        DropDownEffect.onValueChanged.AddListener(DropdownEffect_Changed);
        DropDownEffect.value = graphicSetting.screenEffect;

        ToggleShowFps.isOn = graphicSetting.showFps;
        ToggleShowFps.onValueChanged.AddListener(ToggleShowFps_Changed);
    }

    private void Event_FieldOfViev_Change(int value)
	{
        SliderTextView.Value = value;
    }

    private void Event_MaxFps_Change(int value)
    {
        SliderTextMaxFps.Value = value;
    }

    public void SliderFPS_Changed(float index)
    {
        graphicSetting.maxFPS = (int)index;
    }

    public void SliderView_Changed(float index)
    {
        graphicSetting.fieldOfView = (int)index;
    }

    public void DropdownQuality_Changed(int index)
    {
        graphicSetting.qualityLevel = index;
    }

    public void DropdownSync_Changed(int index)
    {
        graphicSetting.syncCount = index;
    }

    public void DropdownEffect_Changed(int index)
    {
        graphicSetting.screenEffect = index;
    }

    public void ToggleShowFps_Changed(bool value)
    {
        graphicSetting.showFps = value;
    }

    public override void SetupDefaultOption()
	{
        graphicSetting.SetupDefaultSetting();
    }
}
