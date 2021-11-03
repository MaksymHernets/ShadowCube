using UnityEngine;
using UnityEngine.UI;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] private Text textVersion;

    public GameObject menuMain;
    public GameObject menuPlay;
    public GameObject menuOnline;
    public GameObject menuPerson;
    public GameObject menuOptions;
    public GameObject menuAbout;

    public GameObject buttonBack;

    private void Start()
    {
        textVersion.text = "ALPHA " + Application.version;
    }

    #region MainMenu
    private void CommonAction()
	{
        menuMain.SetActive(false);
        buttonBack.SetActive(true);
    }

    public void ButtonPlay_Click()
    {
        CommonAction();
        menuPlay.SetActive(true);
    }

    public void ButtonOnline_Click()
    {
        CommonAction();
        menuOnline.SetActive(true);
    }

    public void ButtonPerson_Click()
    {
        CommonAction();
        menuPerson.SetActive(true);
    }

    public void ButtonOptions_Click()
    {
        CommonAction();
        menuOptions.SetActive(true);
    }

    public void ButtonManual_Click()
    {
        CommonAction();
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
