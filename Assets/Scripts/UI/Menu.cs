using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject player;

    public GameObject buttonStatus;
    public GameObject buttonOptions;
    public GameObject buttonClose;
    public GameObject buttonLeave;
    public GameObject table;
    
    private bool key = false;

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
        buttonStatus.SetActive(key);
        buttonOptions.SetActive(key);
        buttonClose.SetActive(key);
        buttonLeave.SetActive(key);
        table.SetActive(key);
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
