﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryControl : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;
    [SerializeField] private ControlPlayerPC controlPlayerPC;
    [SerializeField] private ControlPlayerAndroid controlPlayerAndroid;

	private void Start()
	{
		if ( Application.platform == RuntimePlatform.WindowsPlayer)
		{
			GameObject.Instantiate(controlPlayerPC).Init(playerLogic);
		}
		else if ( Application.platform == RuntimePlatform.Android )
		{
			GameObject.Instantiate(controlPlayerAndroid).Init(playerLogic);
		}
	}
}
