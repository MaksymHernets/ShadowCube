using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ShadowCube.DTO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    public Text textversion;

    public GameObject menuMain;
    public GameObject menuPlay;
    public GameObject menuOnline;
    public GameObject menuPerson;
    public GameObject menuOptions;
    public GameObject menuAbout;

    private void Start()
    {
        textversion.text = "ALPHA " + Application.version;
    }

    #region MainMenu
    public void ButtonPlay_Click()
    {
        menuMain.SetActive(false);
        menuPlay.SetActive(true);
    }

    public void ButtonOnline_Click()
    {
        menuMain.SetActive(false);
        menuOnline.SetActive(true);
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

    public void ButtonExit_Click()
    {
        Application.Quit();
    }

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
