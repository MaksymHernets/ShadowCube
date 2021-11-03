using System.Collections;
using UnityEngine;

namespace Cubes.CubeFour
{
	public class DoorLogic5 : DoorLogic
    {
        [SerializeField] private GameObject door;
        [SerializeField] private GameObject doorhandle;

        [SerializeField] private AudioSource audio_door;
        [SerializeField] private AudioSource audio_doorhandle;

        private float speedToOpen0 = 2f;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audio_doorhandle.Play();
                StartCoroutine(
                    Animation_Doorhandle(2f, doorhandle.transform.localRotation,
                    Quaternion.Euler(doorhandle.transform.localEulerAngles.x, doorhandle.transform.localEulerAngles.y + 180f, 
                    doorhandle.transform.localEulerAngles.z)));
                _doorStage = DoorStage.open;
                _wallLogic.OpenedDoor();
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open)
            {
                _doorStage = DoorStage.closing;
                audio_door.Play();
                StartCoroutine(Animation_DoorTwoClose(3f, new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, door.transform.localPosition.z - 0.45f)));
                _doorStage = DoorStage.closed;
                _wallLogic.ClosedDoor();
            }
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
