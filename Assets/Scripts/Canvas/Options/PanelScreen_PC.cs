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
    [SerializeField] private Dropdown DropDownVertSync;
    [SerializeField] private SliderTextUI sliderTextScaleRender;
    [SerializeField] private SliderTextUI SliderTextMaxFps;
    [SerializeField] private SliderTextUI SliderTextView;
    
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

        DropDownVertSync.ClearOptions();
        DropDownVertSync.AddOptions(screenSetting.GetNamesSync());
        DropDownVertSync.onValueChanged.AddListener(DropdownSync_Changed);
        DropDownVertSync.value = screenSetting.syncCount;

        sliderTextScaleRender.slider.onValueChanged.AddListener(SliderScaleRender_Changed);
        sliderTextScaleRender.Value = screenSetting.scaleRender;
        sliderTextScaleRender.slider.minValue = screenSetting.MinScaleRender;
        sliderTextScaleRender.slider.maxValue = screenSetting.MaxScaleRender;

        SliderTextMaxFps.slider.onValueChanged.AddListener(SliderFPS_Changed);
        SliderTextMaxFps.slider.minValue = screenSetting.MinFPS;
        SliderTextMaxFps.slider.maxValue = screenSetting.MaxMaxFPS;
        SliderTextMaxFps.Value = screenSetting.maxFPS;
        screenSetting.MaxFPS += Event_MaxFps_Change;

        SliderTextView.slider.onValueChanged.AddListener(SliderView_Changed);
        SliderTextView.slider.minValue = screenSetting.MinViewCamera;
        SliderTextView.slider.maxValue = screenSetting.MaxViewCamera;
        SliderTextView.Value = screenSetting.fieldOfView;
        screenSetting.FieldOfView += Event_FieldOfViev_Change;
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

    public void DropdownSync_Changed(int index)
    {
        screenSetting.syncCount = index;
    }

    public void SliderScaleRender_Changed(float index)
    {
        screenSetting.scaleRender = index;
    }

    private void Event_FieldOfViev_Change(int value)
    {
        SliderTextView.Value = value;
    }

    public void SliderFPS_Changed(float index)
    {
        screenSetting.maxFPS = (int)index;
    }

    public void SliderView_Changed(float index)
    {
        screenSetting.fieldOfView = (int)index;
    }

    private void Event_MaxFps_Change(int value)
    {
        SliderTextMaxFps.Value = value;
    }
}
