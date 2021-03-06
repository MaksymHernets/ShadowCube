﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsLogic : MonoBehaviour
{
    public GameObject MainMenu;

    [Header("Panels")]
    public GameObject panelGeneric;
    public GameObject panelControl;
    public GameObject panelGraphic;

    [Header("Generic")]
    public Slider SliderSound;
    public Text LabelSoundValue;

    [Header("Graphic")]
    public Dropdown DropDownScale;
    public Dropdown DropDownScreenMode;
    public Dropdown DropDownSync;
    public Slider SliderMaxFps;
    public Dropdown DropDownQuality;


    private void Awake()
	{
        SliderSound.value = AudioListener.volume;
        LabelSoundValue.text = SliderSound.value.ToString("G") + "%";

        InsertDropdownScale();
        DropDownSync.value = QualitySettings.vSyncCount;
        SliderMaxFps.value = QualitySettings.maxQueuedFrames;
        InsertDropdownQuality();
    }

    

	#region Bar
	public void ButtonGeneric_Click()
    {
        panelGeneric.SetActive(true);
        panelControl.SetActive(false);
        panelGraphic.SetActive(false);
    }

    public void ButtonControl_Click()
    {
        panelControl.SetActive(true);
        panelGeneric.SetActive(false);
        panelGraphic.SetActive(false);
    }

	public void ButtonGraphic_Click()
	{
		panelControl.SetActive(false);
		panelGeneric.SetActive(false);
		panelGraphic.SetActive(true);
	}
    #endregion

    #region Generic
    public void SliderSound_Changed(float value)
    {
        LabelSoundValue.text = value.ToString("G") + "%";
        AudioListener.volume = value * 0.01f;
    }
    #endregion

    #region Graphic
    public void DropdownScale_Changed(int index)
    {
        Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, Screen.fullScreenMode);
    }

    private void InsertDropdownScreenMode()
    {
        if ( Screen.fullScreenMode == FullScreenMode.FullScreenWindow) { DropDownScreenMode.value = 0; }
        else if (Screen.fullScreenMode == FullScreenMode.Windowed) { DropDownScreenMode.value = 1; }
        else if (Screen.fullScreenMode == FullScreenMode.MaximizedWindow) { DropDownScreenMode.value = 2; }
    }

    private void InsertDropdownScale()
    {
        DropDownScale.AddOptions(Screen.resolutions.Select(w => w.ToString()).ToList() );
        int index = 0;
        foreach (var item in Screen.resolutions)
        {
            //if (Screen.currentResolution.refreshRate == item.refreshRate)
            if ( (item.width == Screen.currentResolution.width) && (item.height == Screen.currentResolution.height) && (item.refreshRate == Screen.currentResolution.refreshRate) )
            {
                DropDownScale.value = index;
                break;
            }
            index++;
        }
    }

    private void InsertDropdownQuality()
    {
        DropDownQuality.AddOptions(QualitySettings.names.ToList());
        DropDownQuality.value = QualitySettings.GetQualityLevel();
    }

    public void SliderFPS_Changed(float index)
    {
        //TextFpsValue.text = index.ToString("G");
        QualitySettings.maxQueuedFrames = (int)index;
    }

    public void SliderView_Changed(float index)
    {
        //TextViewValue.text = index.ToString("G");
    }

    public void InputFieldFps_Changed(string fps)
    {
        int intfps = int.Parse(fps);
        //TextFpsValue.text = intfps.ToString();
        //SliderMaxfps.value = intfps;
        QualitySettings.maxQueuedFrames = intfps;
    }

    public void DropdownQuality_Changed(int index)
    {
        QualitySettings.SetQualityLevel(index, true);//Изменяем уровен графики
    }

    public void DropdownSync_Changed(int index)
    {
        QualitySettings.vSyncCount = index;
    }

    public void DropdownMode_Changed(int index)
    {
        switch (index)
        {
            case 0: Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow); break;
            case 1: Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.Windowed); break;
            case 2: Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.MaximizedWindow); break;
        }
    }

    public void DropdownEffect_Changed(int index)
    {
        //snapshotModeSelect.filterIndex = index;
    }
    #endregion

    public void ButtonBack_Click()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
