using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonLogic : MonoBehaviour
{
    public GameObject cameramoveone;
	public CPC_CameraPath cameraPath;
	public GameObject person;


	private void OnEnable()
	{
		cameramoveone.SetActive(false);
		cameraPath.points.Reverse();
		cameraPath.PlayPath(2);
		person.SetActive(true);
	}

	private void OnDisable()
	{
		cameraPath.points.Reverse();
		cameraPath.PlayPath(2);
		person.SetActive(false);
	}

	//public void Button
}
