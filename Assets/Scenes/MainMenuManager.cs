using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ShadowCube.DTO;

public class MainMenuManager : MonoBehaviour
{
    public GameObject cameramoveone;

    public List<GameObject> Cubes;

    public GameObject menuMain;
    public GameObject menuPlay;
    public GameObject menuOnline;
    public GameObject menuPerson;
    public GameObject menuOptions;
    public GameObject menuAbout;

    public GameObject buttonBack;

    private void Start()
	{
        Cookie.mainPlayer = new PlayerDTO();
        Cookie.mainPlayer.Name = "ShadowMan";
        Cookie.mainPlayer.Sex = true;


        ShowCube(0, Cookie.room.IndexCube);
    }

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ButtonBack_Click();
		}
	}

	public void ButtonBack_Click()
	{
		menuMain.SetActive(true);
		menuPlay.SetActive(false);
		menuOnline.SetActive(false);
		menuAbout.SetActive(false);
		menuOptions.SetActive(false);
		menuPerson.SetActive(false);
        cameramoveone.SetActive(true);
        buttonBack.SetActive(false);
    }

	public void Play()
	{
        buttonBack.SetActive(false);
        Cubes[Cookie.room.IndexCube].SendMessage("OpenDoor", 2);
        cameramoveone.SetActive(false);
        Camera.main.transform.localEulerAngles = new Vector3(0, 90, 0);
        StartCoroutine(Animation_Camera());
    }

    public void ShowCube(int index, int index2)
	{
        Cubes[index].SetActive(false);
        Cubes[index2].SetActive(true);
    }

    IEnumerator Animation_Camera()
    {
        yield return new WaitForSecondsRealtime(4f);
        for (int i = 0; i < 120; i++)
        {
            Camera.main.transform.position += new Vector3(0.02f, 0f, 0f);
            yield return new WaitForSecondsRealtime(0.03f);
        }
        SceneManager.LoadScene(1);
    }
}
