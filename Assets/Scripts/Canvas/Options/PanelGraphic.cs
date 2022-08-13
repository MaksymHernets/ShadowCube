using ShadowCube.Setting;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelGraphic : OptionPanel
{
    [Header("Graphic")]
    [SerializeField] private Dropdown DropDownQuality;

    [Inject] GraphicSetting graphicSetting;

	private void Start()
	{
        DropDownQuality.ClearOptions();
        DropDownQuality.AddOptions(graphicSetting.GetNamesQualityLevel().ToList());
        DropDownQuality.onValueChanged.AddListener(DropdownQuality_Changed);
        DropDownQuality.value = graphicSetting.qualityLevel;
    }

    public void DropdownQuality_Changed(int index)
    {
        graphicSetting.qualityLevel = index;
    }

    public override void SetupDefaultOption()
	{
        graphicSetting.SetupDefaultSetting();
    }
}
