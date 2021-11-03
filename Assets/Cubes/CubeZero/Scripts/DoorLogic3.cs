using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeZero
{
    public class DoorLogic3 : DoorLogic
    {
        [SerializeField] private GameObject door1;
        [SerializeField] private GameObject door2;
        [SerializeField] private GameObject doorhandle;

        [SerializeField] private AudioSource audio_door;

        private float speedToOpen = 0.002f;
        private float speedToOpen2 = 2f;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audio_door.Play();
                StartCoroutine("Animation_DoorHandle");
                _doorStage = DoorStage.open;
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open || _doorStage == DoorStage.opening)
            {
                _doorStage = DoorStage.closing;
                _doorStage = DoorStage.closed;
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
