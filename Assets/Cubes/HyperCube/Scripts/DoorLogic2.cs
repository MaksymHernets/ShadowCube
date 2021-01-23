using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeHyber
{
    public class DoorLogic2 : MonoBehaviour
    {
        public GameObject door;
        public GameObject door1;
        public GameObject door2;
        public GameObject door3;
        public AudioSource audio_door;

        public DoorStage dootstage = DoorStage.closed;

        private float speedToOpen = 0.0015f;

        private void Open()
        {
            if (dootstage == DoorStage.closed)
            {
                dootstage = DoorStage.opening;
                audio_door.Play();
                StartCoroutine(Animation_Door(2f
                    , new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, door.transform.localPosition.z + 0.4f)
                    , new Vector3(door1.transform.localPosition.x, door1.transform.localPosition.y, door1.transform.localPosition.z - 0.4f)
                    )
                    );
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


        IEnumerator Animation_Door(float time, Vector3 endP, Vector3 endP2)
        {
            yield return new WaitForSecondsRealtime(1.9f);
            //for (int i = 0; i < 115; ++i)
            //{
            //    door.transform.localPosition = door.transform.localPosition + new Vector3(0, 0 , -speedToOpen);
            //    door1.transform.localPosition = door1.transform.localPosition + new Vector3(0, 0, speedToOpen);
            //    door2.transform.localPosition = door2.transform.localPosition + new Vector3(0, 0, speedToOpen);
            //    door3.transform.localPosition = door3.transform.localPosition + new Vector3(0, 0, -speedToOpen);
            //    yield return new WaitForSecondsRealtime(0.003f);
            //}
            float sumtime = 0;
            while (time >= sumtime)
            {
                sumtime += Time.deltaTime;
                door.transform.localPosition = Vector3.Lerp(door.transform.localPosition, endP2, Time.deltaTime);
                door1.transform.localPosition = Vector3.Lerp(door1.transform.localPosition, endP, Time.deltaTime);
                //door2.transform.localPosition = Vector3.Slerp(door2.transform.localPosition, endP, Time.deltaTime);
                //door3.transform.localPosition = Vector3.Slerp(door3.transform.localPosition, endP2, Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
            //yield return new WaitForSecondsRealtime(1f);
        }
    }
}
