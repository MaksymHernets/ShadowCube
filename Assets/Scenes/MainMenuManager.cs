﻿using ShadowCube.Setting;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using ShadowCube.Cubes;
using ShadowCube.Controller;
using ShadowCube.Models;
using UnityEngine.Localization.Settings;

namespace ShadowCube.Scenes
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private List<CubeLogic> Cubes;
        [SerializeField] private List<CubeLogic> CubesFirst;
        [SerializeField] private MusicFonManager MusicFonManager;

        [Header("Controllers")]
        [SerializeField] private ControllerMainMenu mainMenu;
        [SerializeField] private ControllerPlayMenu menuPlay;
        [SerializeField] private ControllerOnlineMenu menuOnline;
        [SerializeField] private ControllerPersonMenu menuPerson;
        [SerializeField] private ControllerOptionMenu menuOptions;
        [SerializeField] private ControllerAbout menuAbout;

        [Header("Other")]
        [SerializeField] private GameObject person;

        private string _namePanel;

        [Inject] GameSetting gameSetting;

        private void Start()
        {
            mainMenu.EventButtonClick += Event_ButtonClick;
            mainMenu.EventClose.AddListener(Handler_MainMenu_Close);

            menuPlay.EventButtonPlayClick.AddListener(Event_ButtonPlayClick);
            menuPlay.EventClose.AddListener(Event_Menu_Close);
            menuOnline.EventClose.AddListener(Event_Menu_Close);
            menuPerson.EventClose.AddListener(Event_MenuPerson_Close);
            menuOptions.EventClose.AddListener(Event_Menu_Close);
            menuAbout.EventClose.AddListener(Event_Menu_Close);

            ShowCubeFirst(0, gameSetting.indexCube);
            CubesFirst[gameSetting.indexCube].OpenDoor(2);
            Cubes[gameSetting.indexCube].OpenDoor(4);
            Invoke("Intro_End", 9f);
        }

        private void Event_ButtonPlayClick()
        {
            Dispose();
            Cubes[gameSetting.indexCube].OpenDoor(2);
            animator.SetBool("End", true);
            Invoke("LoadSceneGame", 8f);
        }

        private void Event_ButtonClick(string name)
        {
            _namePanel = name;
            mainMenu.Deactive();
        }

        private void Handler_MainMenu_Close()
        {
            switch (_namePanel)
            {
                case "PlayMenu": menuPlay.Init(new ModelPlayMenu() { mainMenuManager = this }); break;
                case "OnlineMenu": menuOnline.Init(new ModelOnlineMenu()); break;
                case "PersonMenu":
                    person.SetActive(true);
                    animator.SetBool("PersonEnd", false);
                    animator.SetBool("PersonStart", true);
                    menuPerson.Init(new ModelPersonMenu(gameSetting.playerDTO));
                    break;
                case "OptionMenu": menuOptions.Init(new ModelOptionMenu()); break;
                case "AboutMenu": menuAbout.Init(new IModel()); break;
            }
        }

        private void Intro_End()
		{
            mainMenu.Init(new IModel());
            CubesFirst[gameSetting.indexCube].CloseDoor(2);
            Cubes[gameSetting.indexCube].CloseDoor(4);
            Observable.Timer(System.TimeSpan.FromSeconds(7f))
            .Subscribe(_ => { DeleteCubesFirst(); });
        }

        private void Event_Menu_Close()
        {
            mainMenu.Init(new IModel());
        }

        private void Event_MenuPerson_Close()
        {
            person.SetActive(false);
            animator.SetBool("PersonStart", false);
            animator.SetBool("PersonEnd", true);
            Observable.Timer(System.TimeSpan.FromSeconds(2f))
            .Subscribe(_ => { mainMenu.Init(new IModel()); });
        }

        public void ShowCubeSecond(int oldIndex, int newIndex)
        {
            Cubes[oldIndex].gameObject.SetActive(false);
            Cubes[newIndex].gameObject.SetActive(true);
            MusicFonManager.Play(newIndex);
        }

        public void ShowCubeFirst(int oldIndex, int newIndex)
        {
            ShowCubeSecond(oldIndex, newIndex);
            CubesFirst[oldIndex].gameObject.SetActive(false);
            CubesFirst[newIndex].gameObject.SetActive(true);
        }

        private void DeleteCubesFirst()
		{
			foreach (var cube in CubesFirst)
			{
				GameObject.Destroy(cube.gameObject);
			}
		}

        private void Dispose()
        {
            mainMenu.EventButtonClick -= Event_ButtonClick;

            menuPlay.EventButtonPlayClick.RemoveListener(Event_ButtonPlayClick);
            menuPlay.EventClose.RemoveListener(Event_Menu_Close);
            menuOnline.EventClose.RemoveListener(Event_Menu_Close);
            menuPerson.EventClose.RemoveListener(Event_Menu_Close);
            menuOptions.EventClose.RemoveListener(Event_Menu_Close);
            menuAbout.EventClose.RemoveListener(Event_Menu_Close);
        }

        private void LoadSceneGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}
