using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public GameObject menuMain;
    public GameObject menuPlay;
    public GameObject menuPerson;
    public GameObject menuOptions;
    public GameObject menuAbout;

    public Text buttonPrivatePublic;
    public Button[] maps;
    public Text textCountPlayers;
    public Toggle toggleAddBots;
    public Input inputCode;

	public GameObject panelGeneric;
    public GameObject panelControl;

    private Room room = new Room();
    private List<Player> players = new List<Player>();

    private void Start()
    {
        Cookie.mainPlayer = new Player();
        Cookie.mainPlayer.name = "ShadowMan";
        Cookie.mainPlayer.IsBot = false;
        Cookie.mainPlayer.sex = true;
        players.Add(Cookie.mainPlayer);
    }

    private void Update()
	{
		if ( Input.GetKeyDown(KeyCode.Escape))
		{
            ButtonBack_Click();
        }
	}

	#region MainMenu
    public void ButtonPlay_Click()
	{
        menuMain.SetActive(false);
        menuPlay.SetActive(true);
    }

    public void ButtonPerson_Click()
    {
        menuMain.SetActive(false);
        menuPerson.SetActive(true);
    }

    public void ButtonOptions_Click()
    {
        menuMain.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void ButtonManual_Click()
    {
        menuMain.SetActive(false);
        menuAbout.SetActive(true);
    }
    #endregion

    #region Play
    public void ButtonStart_Click()
    {
        if ( toggleAddBots.isOn )
		{
            for (int i = 0; i < room.Size - players.Count; i++)
            {
                players.Add(new Player());
            }
        }
        Cookie.room = room;
        Cookie.players = players;

        SceneManager.LoadScene(1);
    }
    #region Maps
    public void ButtonCubeOne_Click()
    {
        ChangedButton(room.IndexCube, 0);
        room.IndexCube = 0;
    }

    public void ButtonHyberCube_Click()
    {
        ChangedButton(room.IndexCube, 1);
        room.IndexCube = 1;
    }

    public void ButtonCubeZero_Click()
    {
        ChangedButton(room.IndexCube, 2);
        room.IndexCube = 2;
    }

    public void ButtonNewCube_Click()
    {
        ChangedButton(room.IndexCube, 3);
        room.IndexCube = 3;
    }

    private void ChangedButton(int oldindex, int newindex)
	{
        maps[oldindex].image.color = new Color(255f, 255f, 255f, 120f);
        maps[newindex].image.color = Color.gray;
    }
    #endregion

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
    #endregion

    #region Generic
    public void ButtonBack_Click()
    {
        menuMain.SetActive(true);
        menuAbout.SetActive(false);
        menuOptions.SetActive(false);
        menuPerson.SetActive(false);
        menuPlay.SetActive(false);
    }

    public void ButtonExit_Click()
    {
        Application.Quit();
    }
    #endregion

    #region Options
    public void ButtonGeneric_Click()
    {
        panelGeneric.SetActive(true);
        panelControl.SetActive(false);
    }

    public void ButtonControl_Click()
	{
        panelControl.SetActive(true);
        panelGeneric.SetActive(false);
    }
	#endregion
}

public class Room
{
    public string Code { get; set; }
    public int Size { get; set; }
    public bool IsPrivate  { get; set; }
    public int IndexCube { get; set; }

    public Room()
	{
        Code = "WWWWWW";
        Size = 7;
        IsPrivate = true;
        IndexCube = 0;
    }
}
