using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Button buttonreturn;

    delegate void Die();

    public void ButtonLeave_Click()
    {
	    SceneManager.LoadScene(0);
    }

    public void ButtonOverwatch_Click()
    {

    }


}
