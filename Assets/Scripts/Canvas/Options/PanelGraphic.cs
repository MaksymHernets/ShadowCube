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
    [SerializeField] private Dropdown DropDownQuality;
    [SerializeField] private SliderTextUI SliderText_MaximumLODLevel;
    [SerializeField] private Toggle Toggle_ShowFps;

    [Inject] GraphicSetting graphicSetting;

	private void Start()
	{
        DropDownQuality.ClearOptions();
        DropDownQuality.AddOptions(graphicSetting.GetNamesQualityLevel().ToList());
        DropDownQuality.onValueChanged.AddListener(DropdownQuality_Changed);
        DropDownQuality.value = graphicSetting.qualityLevel;

        SliderText_MaximumLODLevel.slider.onValueChanged.AddListener(SliderMaximumLODLevel_Changed);
        SliderText_MaximumLODLevel.slider.minValue = 0;
        SliderText_MaximumLODLevel.slider.maxValue = graphicSetting.MaxMaximumLODLevel;
        SliderText_MaximumLODLevel.Value = graphicSetting.maximumLODLevel;

        Toggle_ShowFps.isOn = graphicSetting.showFps;
        Toggle_ShowFps.onValueChanged.AddListener(ToggleShowFps_Changed);

        graphicSetting.QualityLevel += Update_QualityLevel;
    }

    public override void SetupDefaultOption()
    {
        graphicSetting.SetupDefaultSetting();
    }

    public void Update_QualityLevel(int level)
	{
        SliderText_MaximumLODLevel.Value = QualitySettings.maximumLODLevel;
    }

    public void DropdownQuality_Changed(int index)
    {
        graphicSetting.qualityLevel = index;
    }

    public void SliderMaximumLODLevel_Changed(float index)
    {
        graphicSetting.maximumLODLevel = (int)index;
    }

    public void ToggleShowFps_Changed(bool value)
    {
        graphicSetting.showFps = value;
    }
}
