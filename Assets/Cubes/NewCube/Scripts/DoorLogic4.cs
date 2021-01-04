using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeNew
{
    public class DoorLogic4 : MonoBehaviour
    {
        public GameObject door;
        public GameObject doorhandle;

        public DoorStage dootstage = DoorStage.closed;
        private float speedToOpen0 = 2f;
        private float speedToOpen1 = 0.004f;
        private float speedToOpen2 = 0.005f;

        public AudioSource audio_door;
        public AudioSource audio_doorhandle;

        private void Open()
        {
            if (dootstage == DoorStage.closed)
            {
                dootstage = DoorStage.opening;
                StartCoroutine("Animation_Doorhandle");
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
                //audio_door.Play();
                //StartCoroutine("Animation_Doorhandle");
                dootstage = DoorStage.closed;
            }
        }

        #region Animation Open
        IEnumerator Animation_Doorhandle()
        {
            audio_doorhandle.Play();
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + speedToOpen0, doorhandle.transform.localEulerAngles.z);
                yield return new WaitForSeconds(0.01f);
            }
            StartCoroutine("Animation_DoorOne");
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOne()
        {
            audio_doorhandle.Stop();
            audio_door.Play();
            for (int i = 0; i < 12; ++i)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, -speedToOpen1, 0);
                yield return new WaitForSeconds(0.005f);
            }
            StartCoroutine("Animation_DoorTwo");
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwo()
        {
            for (int i = 0; i < 90; ++i)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, 0, speedToOpen2);
                yield return new WaitForSeconds(0.02f);
            }
        }
        #endregion
    }
}
