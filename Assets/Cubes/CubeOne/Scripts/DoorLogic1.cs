using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeOne
{
    public class DoorLogic1 : MonoBehaviour
    {
        public GameObject door;
        public GameObject doorhandle;

        public AudioSource audio_door;
        public AudioSource audio_doorhandle;

        public DoorStage dootstage = DoorStage.closed;

        private int CountPlayers = 0;
        private float TimeWait = 10;
        private float TimeLost = 0;

        private float speedToOpen0 = 2f;
        private float speedToOpen1 = 0.004f;
        private float speedToOpen2 = 0.005f;

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

        public void Using()
        {
            if(dootstage == DoorStage.closed)
            {
                UserToOpen();
            }
            else if (dootstage == DoorStage.open)
            {
                //UserToClose();
            }
        }

        public void UserToOpen()
        {
            Open();
            transform.parent.gameObject.SendMessage("OpenedDoor");
        }

        public void UserToClose()
        {
            Close();
            transform.parent.gameObject.SendMessage("OpenedDoor");
        }

        public void MegaCubeToClose()
        {
            Close();
        }

        public void MegaCubeToOpen()
        {
            Open();
        }

        public void Close()
        {
            if (dootstage == DoorStage.open)
            {
                dootstage = DoorStage.closing;
                StartCoroutine("Animation_DoorTwoClose");
                dootstage = DoorStage.closed;
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                ++CountPlayers;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                --CountPlayers;
            }
        }

        public void Update()
        {
            //if (CountPlayers == 0)
            //{
            //    TimeLost += Time.deltaTime;
            //    if (TimeWait <= TimeLost)
            //    {
            //        transform.parent.gameObject.SendMessage("ClosedDoor");
            //        TimeLost = 0;
            //    }
            //}
        }

        #region Animation Open
        IEnumerator Animation_Doorhandle()
        {
            audio_door.Play();
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + speedToOpen0, doorhandle.transform.localEulerAngles.z);
                yield return new WaitForSecondsRealtime(0.009f);
            }
            StartCoroutine("Animation_DoorOne");
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOne()
        {
            for (int i = 0; i < 12; ++i)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, speedToOpen1, 0);
                yield return new WaitForSecondsRealtime(0.01f);
            }
            StartCoroutine("Animation_DoorTwo");
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwo()
        {
            for (int i = 0; i < 85; ++i)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, 0, speedToOpen2);
                yield return new WaitForSecondsRealtime(0.024f);
            }
        }
        #endregion

        #region Animation Close
        IEnumerator Animation_DoorhandleClose()
        {
            //audio_door.Play();
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y - speedToOpen0, doorhandle.transform.localEulerAngles.z);
                yield return null;
            }
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOneClose()
        {
            for (int i = 0; i < 12; i++)
            {
                transform.localPosition = transform.localPosition - new Vector3(0, speedToOpen1, 0);
                yield return new WaitForSecondsRealtime(0.009f);
            }
            StartCoroutine("Animation_DoorhandleClose");
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwoClose()
        {
            for (int i = 0; i < 85; i++)
            {
                transform.localPosition = transform.localPosition - new Vector3(0, 0, speedToOpen2);
                yield return new WaitForSecondsRealtime(0.024f);
            }
            StartCoroutine("Animation_DoorOneClose");
        }
        #endregion
    }
}
