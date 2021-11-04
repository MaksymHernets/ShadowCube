using ShadowCube.Setting;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControllerOptionMenu : IController
{
    [SerializeField] private Button buttonBack;

    [Header("Bar")]
    [SerializeField] private Button buttonGeneric;
    [SerializeField] private Button buttonControl;
    [SerializeField] private Button buttonGraphic;

    [Header("Panels")]
    [SerializeField] private GameObject panelGeneric;
    [SerializeField] private GameObject panelControl;
    [SerializeField] private GameObject panelGraphic;

    [Header("Generic")]
    [SerializeField] private Dropdown DropDownLanguage;
    [SerializeField] private SliderTextUI sliderTextSound;
    [SerializeField] private SliderTextUI sliderTextMusic;
    [SerializeField] private Dropdown DropDownRegion;

    [Header("Control")]
    [SerializeField] private SliderTextUI sliderTextMouse;
    [SerializeField] private Button buttonApply;

    [Header("Graphic")]
    [SerializeField] private Dropdown DropDownScale;
    [SerializeField] private Dropdown DropDownScreenMode;
    [SerializeField] private Dropdown DropDownSync;
    [SerializeField] private SliderTextUI SliderTextMaxFps;
    [SerializeField] private SliderTextUI SliderTextView;
    [SerializeField] private Dropdown DropDownQuality;
    [SerializeField] private Dropdown DropDownEffect;

    [Inject] GenericSetting genericSetting;
    [Inject] ControlSetting controlSetting;
    [Inject] GraphicSetting graphicSetting;

    protected ModelOptionMenu _model;

    public override void Init(IModel model)
    {
        _model = model as ModelOptionMenu;

        gameObject.SetActive(true);

        InitGeneric();
        InitGraphic();
        InitControl();
    }

    private void InitGeneric()
	{
        sliderTextSound.Value = genericSetting.globalSound;
        sliderTextMusic.Value = genericSetting.globalMusic;
    }

    private void InitControl()
	{
        sliderTextMouse.Value = controlSetting.speedMouse;
    }

    private void InitGraphic()
	{
        InsertDropdownScale();
        InsertDropdownQuality();

        DropDownSync.value = QualitySettings.vSyncCount;
        SliderTextMaxFps.Value = graphicSetting.maxFPS;
    }

	private void Start()
	{
        buttonBack.onClick.AddListener(ButtonBack_Click);

        if ( Application.platform != RuntimePlatform.WindowsPlayer &&
            Application.platform != RuntimePlatform.WindowsEditor &&
            Application.platform != RuntimePlatform.OSXEditor &&
            Application.platform != RuntimePlatform.OSXPlayer )
        {
            buttonControl.gameObject.SetActive(false);
        }

        buttonGeneric.onClick.AddListener(ButtonGeneric_Click);
        buttonControl.onClick.AddListener(ButtonControl_Click);
        buttonGraphic.onClick.AddListener(ButtonGraphic_Click);

        sliderTextSound.slider.onValueChanged.AddListener(SliderSound_Changed);
        sliderTextMusic.slider.onValueChanged.AddListener(SliderMusic_Changed);
        sliderTextMouse.slider.onValueChanged.AddListener(SliderMouse_Changed);

        SliderTextMaxFps.slider.onValueChanged.AddListener(SliderFPS_Changed);

        DropDownEffect.onValueChanged.AddListener(DropdownEffect_Changed);
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
        genericSetting.globalSound = value;
    }

    public void SliderMusic_Changed(float value)
    {
        genericSetting.globalMusic = value;
    }
    #endregion

    #region Control
    public void SliderMouse_Changed(float value)
    {
        controlSetting.speedMouse = value;
    }
    #endregion

    #region Graphic
    public void DropdownScale_Changed(int index)
    {
        Screen.SetResolution(Screen.resolutions[index].width, Screen.resolutions[index].height, Screen.fullScreenMode);
    }

    private void InsertDropdownScreenMode()
    {
        if (Screen.fullScreenMode == FullScreenMode.FullScreenWindow) { DropDownScreenMode.value = 0; }
        else if (Screen.fullScreenMode == FullScreenMode.Windowed) { DropDownScreenMode.value = 1; }
        else if (Screen.fullScreenMode == FullScreenMode.MaximizedWindow) { DropDownScreenMode.value = 2; }
    }

    private void InsertDropdownScale()
    {
        DropDownScale.AddOptions(Screen.resolutions.Select(w => w.ToString()).ToList());
        int index = 0;
        foreach (var item in Screen.resolutions)
        {
            //if (Screen.currentResolution.refreshRate == item.refreshRate)
            if ((item.width == Screen.currentResolution.width) && (item.height == Screen.currentResolution.height) && (item.refreshRate == Screen.currentResolution.refreshRate))
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
        graphicSetting.maxFPS = (int)index;
    }

    public void SliderView_Changed(float index)
    {
        //TextViewValue.text = index.ToString("G");
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
        graphicSetting.screenEffect = index;
    }
    #endregion

    public void ButtonBack_Click()
    {
        Deactive();
    }
}
