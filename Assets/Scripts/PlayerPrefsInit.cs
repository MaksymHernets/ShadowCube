using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInit : MonoBehaviour
{
    void Start()
    {
        if ( !PlayerPrefs.HasKey("Player") )
		{
            //PlayerPrefs.SetString("Player")
        }
		if (!PlayerPrefs.HasKey("GlobalMusic"))
		{
			PlayerPrefs.SetFloat("GlobalMusic", 0f);
		}
		if (!PlayerPrefs.HasKey("Launcher"))
		{
			PlayerPrefs.SetInt("Launcher", 0);
		}
	}
}
