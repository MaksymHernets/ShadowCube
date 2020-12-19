using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeOne
{
    public class DoorLogic : MonoBehaviour
    {
        public GameObject wall;

        public GameObject door;
        public GameObject doorhandle;

        public DoorStage dootstage = DoorStage.closed;
        public float speedToOpen1 = 0.01f;
        public float speedToOpen2 = 0.005f;
        public float speedToOpen3 = 2f;

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
            wall.SendMessage("OpenedDoor");
        }

        public void UserToClose()
        {
            Close();
            wall.SendMessage("OpenedDoor");
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

        #region Animation Open
        IEnumerator Animation_Doorhandle()
        {
            audio_door.Play();
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + speedToOpen3, doorhandle.transform.localEulerAngles.z);
                yield return null;
            }
            StartCoroutine("Animation_DoorOne");
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOne()
        {
            for (int i = 0; i < 12; i++)
            {
                door.transform.localPosition = door.transform.localPosition + new Vector3(0, speedToOpen2, 0);
                yield return null;
            }
            StartCoroutine("Animation_DoorTwo");
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwo()
        {
            for (int i = 0; i < 47; i++)
            {
                door.transform.localPosition = door.transform.localPosition + new Vector3(0, 0, speedToOpen1);
                yield return null;
            }
        }
        #endregion
        #region Animation Close
        IEnumerator Animation_DoorhandleClose()
        {
            audio_door.Play();
            for (int i = 0; i < 90; i++)
            {
                doorhandle.transform.localEulerAngles = new Vector3(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y - speedToOpen3, doorhandle.transform.localEulerAngles.z);
                yield return null;
            }
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOneClose()
        {
            for (int i = 0; i < 12; i++)
            {
                door.transform.localPosition = door.transform.localPosition - new Vector3(0, speedToOpen2, 0);
                yield return null;
            }
            StartCoroutine("Animation_DoorhandleClose");
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwoClose()
        {
            for (int i = 0; i < 47; i++)
            {
                door.transform.localPosition = door.transform.localPosition - new Vector3(0, 0, speedToOpen1);
                yield return null;
            }
            StartCoroutine("Animation_DoorOneClose");
        }
        #endregion
    }
}
