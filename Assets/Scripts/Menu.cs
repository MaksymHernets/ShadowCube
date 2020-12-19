using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool key = false;

    public GameObject menu;
    public GameObject table;
    public GameObject player;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            Activ();
        }
    }

    private void Activ()
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
        //SceneManager.LoadScene(0);
    }

    public void ButtonReturn_Click()
    {
        Activ();
    }
}
