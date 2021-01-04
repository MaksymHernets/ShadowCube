using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeZero
{
    public class DoorLogic3 : MonoBehaviour
    {
        public GameObject door1;
        public GameObject door2;
        public GameObject doorhandle;
        public AudioSource audio_door;

        public DoorStage dootstage = DoorStage.closed;

        private float speedToOpen = 0.002f;
        private float speedToOpen2 = 2f;

        

        private void Open()
        {
            if (dootstage == DoorStage.closed)
            {
                dootstage = DoorStage.opening;
                audio_door.Play();
                StartCoroutine("Animation_DoorHandle");
                dootstage = DoorStage.open;
            }
        }

        public void Using()
        {
            if (dootstage == DoorStage.closed)
            {
                UserToOpen();
            }
        }

        public void UserToOpen()
        {
            Open();
            transform.parent.gameObject.SendMessage("OpenedDoor");
        }

        public void MegaCubeToOpen()
        {
            Open();
        }

        public void Close()
        {
            if (dootstage == DoorStage.open || dootstage == DoorStage.opening)
            {
                dootstage = DoorStage.closing;
                dootstage = DoorStage.closed;
            }
        }

        IEnumerator Animation_DoorHandle()
        {
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + speedToOpen2, doorhandle.transform.localEulerAngles.z);
                yield return new WaitForSeconds(0.01f);
            }
            StartCoroutine("Animation_Door");
        }

        IEnumerator Animation_Door()
        {
            for (int i = 0; i < 90; i++)
            {
                door1.transform.localPosition = door1.transform.localPosition + new Vector3(-speedToOpen, 0, 0);
                door2.transform.localPosition = door2.transform.localPosition + new Vector3(speedToOpen, 0, 0);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
