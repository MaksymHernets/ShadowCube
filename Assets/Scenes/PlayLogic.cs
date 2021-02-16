using ShadowCube.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayLogic : MonoBehaviour
{
    public GameObject MainMenu;
    public MainMenuManager mainMenuManager;

    public Dropdown dropdownMap;
    public Button[] maps;
    public Text buttonPrivatePublic;
    public Text textCountPlayers;
    public Toggle toggleAddBots;
    public Input inputCode;

    private RoomLoby room = new RoomLoby();
    private List<PlayerBase> players = new List<PlayerBase>();

    private void Awake()
    {
        room = Cookie.room;
        dropdownMap.value = Cookie.room.IndexCube;
        ChangedButton(0, Cookie.room.IndexCube);
        players.Add(Cookie.mainPlayer);
    }

    public void DropdownMap_Click(int newindex)
    {
	    mainMenuManager.ShowCube(room.IndexCube, newindex);
	    room.IndexCube = newindex;
    }

    public void ButtonStart_Click()
    {
        if (toggleAddBots.isOn)
        {
            for (int i = 0; i < room.Size - players.Count; i++)
            {
                players.Add(new PlayerBase());
                players[i].IsBot = true;
            }
        }
        Cookie.room = room;
        Cookie.players = players;

        gameObject.SetActive(false);

        mainMenuManager.Play();
    }

    #region Maps
    public void ButtonCubeOne_Click()
    {
        ChangedButton(room.IndexCube, 0);
    }

    public void ButtonHyberCube_Click()
    {
        ChangedButton(room.IndexCube, 1);
    }

    public void ButtonCubeZero_Click()
    {
        ChangedButton(room.IndexCube, 2);
    }

    public void ButtonNewCube_Click()
    {
        ChangedButton(room.IndexCube, 3);
    }

    public void ButtonCubeFour_Click()
    {
	    ChangedButton(room.IndexCube, 4);
    }
    #endregion

    private void ChangedButton(int oldindex, int newindex)
    {
        if (oldindex != newindex)
        {
            room.IndexCube = newindex;
            maps[oldindex].image.color = new Color(0.3f, 0.3f, 0.3f, 0.8f);
            maps[newindex].image.color = Color.black;
            mainMenuManager.ShowCube(oldindex, newindex);
        }
    }

    #region Property
    public void SliderPlayerCount_Click(float value)
    {
        room.Size = (int)value;
        textCountPlayers.text = value.ToString();
    }

    public void ButtonPrivatPublic_Click()
    {
        room.IsPrivate = !room.IsPrivate;
        if (room.IsPrivate)
        {
            buttonPrivatePublic.text = "Private";
        }
        else
        {
            buttonPrivatePublic.text = "Public";
        }
    }
    #endregion

    public void ButtonBack_Click()
    {
        MainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
