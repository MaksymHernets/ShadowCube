using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool key = false;

    public GameObject menu;

    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            key = !key;
            menu.SetActive(key);
        }
    }

    public void ButtonLeave_Click()
	{
        SceneManager.LoadScene(0);
    }
}
