using System.Collections;
using UnityEngine;

namespace Cubes.CubeHyber
{
	public class DoorLogic2 : DoorLogic
    {
        [SerializeField] private GameObject door;
        [SerializeField] private GameObject door1;
        [SerializeField] private GameObject door2;
        [SerializeField] private GameObject door3;

        [SerializeField] private AudioSource audioDoor;

        private float speedToOpen = 0.0015f;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audioDoor.Play();
                StartCoroutine(Animation_Door(2f
                    , new Vector3(door.transform.localPosition.x, door.transform.localPosition.y, door.transform.localPosition.z + 0.4f)
                    , new Vector3(door1.transform.localPosition.x, door1.transform.localPosition.y, door1.transform.localPosition.z - 0.4f)
                    )
                    );
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
            yield return new WaitForSecondsRealtime(1f);
        }
	}
}
