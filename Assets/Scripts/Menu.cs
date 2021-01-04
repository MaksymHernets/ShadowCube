using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool key = false;

    public Canvas maincanvas;
    public GameObject menu;
    public GameObject table;
    public GameObject player;

	public void Start()
	{
        float x = Screen.width / 1920;
        float y = Screen.height / 1080;
        maincanvas.scaleFactor = x;
    }
	void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            Active();
        }
    }

    private void Active()
    {
        key = !key;
        Cursor.visible = key;
        menu.SetActive(key);
        player.SetActive(!key);
    }

    public void ButtonLeave_Click()
	{
        SceneManager.LoadScene(0);
    }
    public void ButtonOptions_Click()
    {
        
    }
    public void ButtonReturn_Click()
    {
        Active();
    }
}
