using ShadowCube.Setting;
using ShadowCube.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelScreen_PC : OptionPanel
{
    [SerializeField] private Dropdown DropDownDisplay;
    [SerializeField] private Dropdown DropDownResolutionScreen;
    [SerializeField] private Dropdown DropDownScreenMode;
    [SerializeField] private SliderTextUI sliderTextScaleRender;

    [Inject] ScreenSetting screenSetting;

    private void Start()
    {
        DropDownResolutionScreen.ClearOptions();
        DropDownResolutionScreen.AddOptions(Screen.resolutions.Select(w => w.ToString()).ToList());
        int index = 0;
        foreach (var item in Screen.resolutions)
        {
            if ((item.width == Screen.currentResolution.width) && (item.height == Screen.currentResolution.height) && (item.refreshRate == Screen.currentResolution.refreshRate))
            {
                DropDownResolutionScreen.value = index;
                break;
            }
            index++;
        }
        DropDownResolutionScreen.onValueChanged.AddListener(DropdownResolution_Changed);

        DropDownScreenMode.ClearOptions();
        DropDownScreenMode.AddOptions(screenSetting.GetNameScreenMode().ToList());
        DropDownScreenMode.value = (int)Screen.fullScreenMode;
        DropDownScreenMode.onValueChanged.AddListener(DropdownMode_Changed);

        DropDownDisplay.ClearOptions();
        DropDownDisplay.AddOptions(screenSetting.GetNameDisplays());

        sliderTextScaleRender.slider.onValueChanged.AddListener(SliderScaleRender_Changed);
        sliderTextScaleRender.Value = screenSetting.scaleRender;
        sliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
        sliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;
    }

    public void DropdownResolution_Changed(int index)
    {
        Resolution resolution = Screen.resolutions[index];
        screenSetting.displayResolution = new Vector2Int(resolution.width, resolution.height);
    }

    public void DropdownMode_Changed(int index)
    {
        screenSetting.screenMode = (FullScreenMode)index;    
    }

    public void SliderScaleRender_Changed(float index)
    {
        screenSetting.scaleRender = index;
    }
}
