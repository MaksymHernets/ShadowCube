using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeNew
{
    public class DoorLogic4 : DoorLogic
    {
        [SerializeField] private GameObject door;
        [SerializeField] private GameObject doorhandle;

        [SerializeField] private AudioSource audio_door;
        [SerializeField] private AudioSource audio_doorhandle;

        private float speedToOpen0 = 2f;
        private float speedToOpen1 = 0.004f;
        private float speedToOpen2 = 0.005f;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                StartCoroutine("Animation_Doorhandle");
                _doorStage = DoorStage.open;
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open || _doorStage == DoorStage.opening)
            {
                _doorStage = DoorStage.closing;
                //audio_door.Play();
                //StartCoroutine("Animation_Doorhandle");
                _doorStage = DoorStage.closed;
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
