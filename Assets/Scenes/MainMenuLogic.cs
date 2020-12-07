using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart_Click()
	{
        SceneManager.LoadScene(1);
    }

    public void ButtonOptions_Click()
    {
        
    }

    public void ButtonManual_Click()
    {

    }

    public void ButtonExit_Click()
    {
        Application.Quit();
    }
}
