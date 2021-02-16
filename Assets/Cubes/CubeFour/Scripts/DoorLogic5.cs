using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeFour
{
    public class DoorLogic5 : MonoBehaviour
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
                StartCoroutine(
                    Animation_Doorhandle(2f, doorhandle.transform.localRotation,
                    Quaternion.Euler(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + 180f, 
                    doorhandle.transform.localEulerAngles.z)));
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
                audio_door.Play();
                StartCoroutine(Animation_DoorTwoClose(3f, new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, door.transform.localPosition.z - 0.45f)));
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
        IEnumerator Animation_Doorhandle(float time, Quaternion start, Quaternion endP)
        {
            float sumtime = 0;
            while (sumtime < time)
            {
	            doorhandle.transform.localRotation = Quaternion.Slerp(start, endP, sumtime/time);
                yield return new WaitForFixedUpdate();
                sumtime += Time.deltaTime;
            }

            doorhandle.transform.localRotation = endP;
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(Animation_DoorOne(0.5f, new Vector3(door.transform.localPosition.x , door.transform.localPosition.y+0.06f , door.transform.localPosition.z)));
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOne(float time, Vector3 endP)
        {
            audio_door.Play();
            float sumtime = 0;
            while ( time >= sumtime)
			{
                sumtime += Time.deltaTime;
                door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, endP, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSecondsRealtime(1f);
            StartCoroutine(Animation_DoorTwo(3f, new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, door.transform.localPosition.z+0.45f)));
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwo(float time, Vector3 endP)
        {
            float sumtime = 0;
            while (time >= sumtime)
            {
                sumtime += Time.deltaTime;
                door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, endP, Time.deltaTime);
                yield return new WaitForFixedUpdate();
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
                yield return new WaitForSecondsRealtime(0.009f);
            }
        }

        // Ввыезд двери вперед
        IEnumerator Animation_DoorOneClose(float time, Vector3 endP)
        {
            audio_door.Play();
            float sumtime = 0;
            while (time >= sumtime)
            {
                sumtime += Time.deltaTime;
                door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, endP, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(Animation_DoorhandleClose());
        }

        // Ввыезд двери вбок
        IEnumerator Animation_DoorTwoClose(float time, Vector3 endP)
        {
            float sumtime = 0;
            while (time >= sumtime)
            {
                sumtime += Time.deltaTime;
                door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, endP, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
            StartCoroutine(Animation_DoorOneClose(0.5f, new Vector3(door.transform.localPosition.x, door.transform.localPosition.y - 0.06f, door.transform.localPosition.z)));
        }
        #endregion
    }
}
