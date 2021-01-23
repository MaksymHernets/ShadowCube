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
        
    }

	void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            Active();
        }
    }

    public void Active()
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
