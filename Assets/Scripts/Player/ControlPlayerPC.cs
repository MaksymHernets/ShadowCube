using DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerPC : MonoBehaviour
{
    public Control control;

    private IPlayerLogic _playerLogic;

    public void Init(IPlayerLogic playerLogic)
    {
        _playerLogic = playerLogic;
    }

	public void Update()
	{
        if (Input.GetKeyDown(control.openitem))
        {
            _playerLogic.OpenInventory();
        }
        if ( Input.GetKeyDown(control.jump) ) 
        {
            _playerLogic.Jump();
        }
        if (Input.GetKeyDown(control.use))
        {
            _playerLogic.ToUse();
        }
        if (Input.GetKeyDown(control.sitdown))
        {
            _playerLogic.SitDown();
        }

        //Input.mousePosition
    }


}
