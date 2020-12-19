using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeZero
{
    public class DoorLogic : MonoBehaviour
    {
        public GameObject wall;

        public GameObject door1;
        public GameObject door2;

        public DoorStage dootstage = DoorStage.closed;
        public float speedToOpen = 0.01f;

        public AudioSource audio_door;

        private void Open()
        {
            if (dootstage == DoorStage.closed)
            {
                dootstage = DoorStage.opening;
                //audio_door.Play();
                StartCoroutine("Animation_Door");
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
            wall.SendMessage("OpenedDoor");
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

        // Ввыезд двери вперед
        IEnumerator Animation_Door()
        {
            for (int i = 0; i < 23; i++)
            {
                door1.transform.localPosition = door1.transform.localPosition + new Vector3(-speedToOpen, 0, 0);
                door2.transform.localPosition = door2.transform.localPosition + new Vector3(speedToOpen, 0, 0);
                yield return null;
            }
        }
    }
}
