﻿using ShadowCube.DTO;
using ShadowCube.Models;
using ShadowCube.Setting;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube.Controller
{
    public class ControllerPlayMenu : IController
    {
        [HideInInspector] public UnityEvent EventButtonPlayClick;

        [SerializeField] private Button buttonBack;
        [SerializeField] private Animator _animator;

        [Header("BarUP")]
        [SerializeField] private Dropdown dropdownMap;
        [SerializeField] private Text buttonPrivatePublic;
        [SerializeField] private Text textCountPlayers;
        [SerializeField] private Toggle toggleAddBots;
        [SerializeField] private Button[] maps;

        [Header("BarDOWN")]
        [SerializeField] private Text inputCode;
        [SerializeField] private Button buttonStart;

        [Inject] GameSetting gameSetting;

        //private RoomLoby room = new RoomLoby();
        private List<Entity> players = new List<Entity>();

        private ModelPlayMenu _model;

        public override void Init(IModel model)
        {
            _model = model as ModelPlayMenu;

            gameObject.SetActive(true);

            inputCode.text = "CODE: " + GetCode();
            dropdownMap.value = gameSetting.indexCube;
        }

        private string GetCode(int length = 6)
        {
            StringBuilder result = new StringBuilder(length);
            result.Length = length;
            for (int i = 0; i < length; ++i)
            {
                result[i] = (char)Random.Range(65, 90);
            }
            return result.ToString();
        }

        private void Start()
        {
            buttonBack.onClick.AddListener(ButtonBack_Click);
            buttonStart.onClick.AddListener(ButtonStart_Click);

            dropdownMap.onValueChanged.AddListener(DropdownMap_Click);
        }

        public void DropdownMap_Click(int newindex)
        {
            _model.mainMenuManager.ShowCube(gameSetting.indexCube, newindex);
            gameSetting.indexCube = newindex;
        }

        public void ButtonStart_Click()
        {
            //if (toggleAddBots.isOn)
            //{
            //    for (int i = 0; i < room.Size - players.Count; i++)
            //    {
            //        players.Add(new Entity());
            //    }
            //}

            _animator.SetBool("Close", true);
            Invoke("Call_EventButtonPlay", 3f);

        }

        private void Call_EventButtonPlay()
        {
            EventButtonPlayClick.Invoke();
        }

        #region Maps
        public void ButtonCubeOne_Click()
        {
            ChangedButton(gameSetting.indexCube, 0);
        }

        public void ButtonHyberCube_Click()
        {
            ChangedButton(gameSetting.indexCube, 1);
        }

        public void ButtonCubeZero_Click()
        {
            ChangedButton(gameSetting.indexCube, 2);
        }

        public void ButtonNewCube_Click()
        {
            ChangedButton(gameSetting.indexCube, 3);
        }

        public void ButtonCubeFour_Click()
        {
            ChangedButton(gameSetting.indexCube, 4);
        }
        #endregion

        private void ChangedButton(int oldindex, int newindex)
        {
            if (oldindex != newindex)
            {
                gameSetting.indexCube = newindex;
                maps[oldindex].image.color = new Color(0.3f, 0.3f, 0.3f, 0.8f);
                maps[newindex].image.color = Color.black;
                _model.mainMenuManager.ShowCube(oldindex, newindex);
            }
        }

        #region Property
        public void SliderPlayerCount_Click(float value)
        {
            //room.Size = (int)value;
            textCountPlayers.text = value.ToString();
        }

        public void ButtonPrivatPublic_Click()
        {
            //room.IsPrivate = !room.IsPrivate;
            //if (room.IsPrivate)
            //{
            //    buttonPrivatePublic.text = "Private";
            //}
            //else
            //{
            //    buttonPrivatePublic.text = "Public";
            //}
        }
        #endregion

        public void ButtonBack_Click()
        {
            _animator.SetBool("Close", true);
            Invoke("Deactive", 3f);
        }
    }
}