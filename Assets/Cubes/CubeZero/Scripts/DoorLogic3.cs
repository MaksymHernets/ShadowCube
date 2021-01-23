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

            StartCoroutine(Animation_Door(1f,
                new Vector3(door1.transform.localPosition.x - 0.45f, door1.transform.localPosition.y, door1.transform.localPosition.z ),
                new Vector3(door2.transform.localPosition.x + 0.45f, door2.transform.localPosition.y, door2.transform.localPosition.z )
                ));
        }

        IEnumerator Animation_Door(float time, Vector3 endP, Vector3 endP2)
        {
            float sumtime = 0;
            while (time >= sumtime)
            {
                sumtime += Time.deltaTime;
                door1.transform.localPosition = Vector3.Lerp(door1.transform.localPosition, endP, Time.deltaTime);
                door2.transform.localPosition = Vector3.Lerp(door2.transform.localPosition, endP2, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
