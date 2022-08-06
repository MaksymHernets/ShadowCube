using ShadowCube.Setting;
using ShadowCube.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelGeneric : OptionPanel
{
    [Header("Generic")]
    [SerializeField] private Dropdown DropDownLanguage;
    [SerializeField] private SliderTextUI sliderTextSound;
    [SerializeField] private SliderTextUI sliderTextMusic;
    [SerializeField] private Dropdown DropDownRegion;

    [Inject] GenericSetting genericSetting;

	private void Start()
	{
        DropDownLanguage.options.Clear();
        DropDownLanguage.AddOptions( genericSetting.GetLanguages() );
        DropDownLanguage.onValueChanged.AddListener(DropDownLanguage_Changed);

        sliderTextSound.Value = genericSetting.globalSound;
        sliderTextSound.slider.onValueChanged.AddListener(SliderSound_Changed);

        sliderTextMusic.Value = genericSetting.globalMusic;
        sliderTextMusic.slider.onValueChanged.AddListener(SliderMusic_Changed);

        DropDownRegion.options.Clear();
        DropDownRegion.AddOptions( genericSetting.GetRegions() );
        DropDownRegion.onValueChanged.AddListener(DropDownRegion_Changed);

        genericSetting.GlobalMusic.Subscribe( Observer.Create<float>( value => sliderTextMusic.Value = value ) );
        genericSetting.GlobalSound.Subscribe( Observer.Create<float>( value => sliderTextSound.Value = value ) );
    }

    public void DropDownLanguage_Changed(int index)
    {
        genericSetting.language = index;
    }

    public void SliderSound_Changed(float value)
    {
        genericSetting.globalSound = value;
    }

    public void SliderMusic_Changed(float value)
    {
        genericSetting.globalMusic = value;
    }

    public void DropDownRegion_Changed(int index)
    {
        genericSetting.region = index;
    }

    public override void SetupDefaultOption()
	{
        genericSetting.SetupDefaultSetting();
    }
}
