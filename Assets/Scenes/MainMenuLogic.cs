using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DTO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public Canvas maincanvas;

    [Header("Main Menu")]
    public GameObject menuMain;
    public GameObject menuPlay;
    public GameObject menuPerson;
    public GameObject menuOptions;
    public GameObject menuAbout;

    [Header("Play")]
    public List<GameObject> Cubes;
    public Button[] maps;
    public Text buttonPrivatePublic;
    public Text textCountPlayers;
    public Toggle toggleAddBots;
    public Input inputCode;
    public GameObject textloading;
    private RoomLoby room = new RoomLoby();
    private List<Player> players = new List<Player>();

    [Header("Person")]

    [Header("Options")]
    public GameObject panelGeneric;
    public GameObject panelControl;
    public GameObject panelGraphic;
    public Dropdown DropDownScale;

    private void Start()
    {


        //IntScreen();
        IntPlay();
        IntPerson();
        IntOptions();
    }

    #region Int
    private void IntScreen()
	{
        float x = Screen.width / 1920;
        float y = Screen.height/ 1080;
        maincanvas.scaleFactor = x;
        //maincanvas.

    }

    private void IntPlay()
    {
        room = Cookie.room;
        Cubes[0].SetActive(false);
        Cubes[Cookie.room.IndexCube].SetActive(true);
    }

    private void IntPerson()
    {
        Cookie.mainPlayer = new Player();
        Cookie.mainPlayer.name = "ShadowMan";
        Cookie.mainPlayer.IsBot = false;
        Cookie.mainPlayer.sex = true;
        players.Add(Cookie.mainPlayer);
    }

    private void IntOptions()
    {
        InsertDropdownScale();
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
            menuPlay.SetActive(false);
            textloading.SetActive(true);
            if (toggleAddBots.isOn)
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

        private void ChangedButton(int oldindex, int newindex)
        {
            if ( oldindex != newindex)
            {
                room.IndexCube = newindex;
                Cubes[oldindex].SetActive(false);
                maps[oldindex].image.color = new Color(0f, 0.9f, 0f, 0.6f);
                maps[newindex].image.color = Color.green;
                Cubes[newindex].SetActive(true);
            }
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

    private void InsertDropdownScale()
    {
        List<string> lists = new List<string>();
        foreach (var item in Screen.resolutions)
        {
            if (Screen.currentResolution.refreshRate == item.refreshRate)
                lists.Add(item.width.ToString() + " X " + item.height.ToString());
        }
        DropDownScale.AddOptions(lists);
    }

    public void DropdownScale_Changed(int index)
    {
        var result = Screen.resolutions.Where(w => w.refreshRate == Screen.currentResolution.refreshRate).ToList();

        Screen.SetResolution(result[index].width, result[index].height, Screen.fullScreenMode);
    }
    #endregion
}

public class RoomLoby
{
    public string Code { get; set; }
    public int Size { get; set; }
    public bool IsPrivate { get; set; }
    public int IndexCube { get; set; }

    public RoomLoby()
    {
        Code = "WWWWWW";
        Size = 7;
        IsPrivate = true;
        IndexCube = 0;
    }
}
