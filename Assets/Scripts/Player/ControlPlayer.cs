using DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
	public PlayerLogic playerLogic;
	public Control control;

	private void Start()
	{
        control = new Control();
        control.use = KeyCode.Mouse0;
        control.openitem = KeyCode.Tab;
    }

	void Update()
    {
        if (Input.GetKeyDown(control.use))
        {
            playerLogic.ToUse();

        }
        else if (Input.GetKeyDown(control.openitem))
        {
            playerLogic.OpenItem();
        }
    }
}
