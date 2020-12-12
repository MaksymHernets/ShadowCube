using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject wall; 

    public GameObject door;
    public GameObject doorhandle;

    public DoorStage dootstage = DoorStage.closed;
    public float speedToOpen = 0.01f;

    public AudioSource audio_door;
    public AudioSource audio_doorhandle;

    private void Open()
	{
        if (dootstage == DoorStage.closed)
        {
            dootstage = DoorStage.opening;
            audio_doorhandle.Play();
            StartCoroutine("Animation_Doorhandle");
            dootstage = DoorStage.open;
        }
    }

    public void UserToOpen()
    {
        Open();
        //Debug.Log("UserToOpen");
        wall.SendMessage("OpenedDoor");
    }

    public void MegaCubeToOpen()
	{
        //Debug.Log("MegaCubeToOpen");
        Open();
    }

    public void Close()
	{
		if (dootstage == DoorStage.open || dootstage == DoorStage.opening)
		{
			dootstage = DoorStage.closing;
			audio_doorhandle.Play();
			StartCoroutine("Animation_Doorhandle");
			dootstage = DoorStage.closed;
		}
	}

    IEnumerator Animation_Doorhandle()
    {
        audio_door.Play();
        for (int i = 0; i < 90; i++)
        {
            doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + 2f, doorhandle.transform.localEulerAngles.z);
            yield return null;
        }
        StartCoroutine("Animation_DoorOne");
    }

    // Ввыезд двери вперед
    IEnumerator Animation_DoorOne()
    {
        for (int i = 0; i < 10; i++)
        {
            door.transform.localPosition = door.transform.localPosition - new Vector3(0, -0.005f, 0);
            yield return null;
        }
        StartCoroutine("Animation_DoorTwo");
    }

    // Ввыезд двери вбок
    IEnumerator Animation_DoorTwo()
    {
        for (int i = 0; i < 47; i++)
        {
            door.transform.localPosition = door.transform.localPosition + new Vector3(0, 0, speedToOpen);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



public interface IDoor
{
    void Open();
    void Close();
}

public enum DoorStage
{
    closed = 0,
    opening = 1,
    open = 2,
    closing = 3,
}
