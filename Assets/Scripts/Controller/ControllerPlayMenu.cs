using ShadowCube.Game;
using ShadowCube.Helpers;
using ShadowCube.Models;
using ShadowCube.Setting;
using ShadowCube.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube.Controller
{
	public class ControllerPlayMenu : IController
    {
        [HideInInspector] public UnityEvent EventButtonPlayClick;

        [SerializeField] private Animator _animator;
        [SerializeField] private Button buttonBack;
        
        [Header("BarUP")]
        [SerializeField] private Dropdown dropdownMap;
        [SerializeField] private SliderTextUI sliderTextUI_CountPlayers;
        [SerializeField] private Toggle toggleAddBots;
        [SerializeField] private SmartButtonUI buttonPrivatePublic;

        [Header("BarDOWN")]
        [SerializeField] private Text inputCode;
        [SerializeField] private Button buttonStart;

        [Inject] GameSetting gameSetting;

        private Lobby lobby;
        private ModelPlayMenu _model;
        private float _timeDeactivate = 1.7f;

        public override void Init(IModel model)
        {
            _model = model as ModelPlayMenu;

            lobby = new Lobby();

            gameObject.SetActive(true);

            sliderTextUI_CountPlayers.slider.minValue = gameSetting.MinPlayers;
            sliderTextUI_CountPlayers.slider.maxValue = gameSetting.MaxPlayers;
            sliderTextUI_CountPlayers.slider.value = gameSetting.MaxPlayers;

            inputCode.text = "CODE: " + GenerateNumber.GetCode(6);

            dropdownMap.ClearOptions();
            dropdownMap.AddOptions( gameSetting.GetCubes() );
            dropdownMap.value = gameSetting.indexCube;

            SetPrivatPublic(lobby.IsPrivate);
        }

        private void Start()
        {
            buttonBack.onClick.AddListener(ButtonBack_Click);
            buttonStart.onClick.AddListener(ButtonStart_Click);

            sliderTextUI_CountPlayers.slider.onValueChanged.AddListener(SliderPlayerCount_Click);

            dropdownMap.onValueChanged.AddListener(DropdownMap_Click);

            buttonPrivatePublic.OnClick += ButtonPrivatPublic_Click;
        }

        public void DropdownMap_Click(int newindex)
        {
            _model.mainMenuManager.ShowCubeSecond(gameSetting.indexCube, newindex);
            gameSetting.indexCube = newindex;
        }

        public void ButtonStart_Click()
        {
            _animator.SetBool("Close", true);
            StartCoroutine( Call_EventButtonPlay() );
        }

        private IEnumerator Call_EventButtonPlay()
        {
            yield return new WaitForSeconds(3f);
            EventButtonPlayClick.Invoke();
        }

        public void SliderPlayerCount_Click(float value)
        {
            
        }

        public void ButtonPrivatPublic_Click(Button button)
        {
            lobby.IsPrivate = !lobby.IsPrivate;
            SetPrivatPublic(lobby.IsPrivate);
        }

        private void SetPrivatPublic(bool key)
		{
            if (key) buttonPrivatePublic.Name.text = "Private";
            else buttonPrivatePublic.Name.text = "Public";
        }

        public void ButtonBack_Click()
        {
            _animator.SetBool("Close", true);
            Invoke("Deactive", _timeDeactivate);
        }
    }
}