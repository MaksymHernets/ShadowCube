using UnityEngine;

namespace Cubes.CubeFour
{
	public class DoorLogic5 : DoorLogic
    {
        [SerializeField] private Animator animator;

        [SerializeField] private AudioSource audio_door;
        [SerializeField] private AudioSource audio_doorhandle;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audio_doorhandle.Play();
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                _doorStage = DoorStage.open;
                //_wallLogic.OpenedDoor();
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open)
            {
                _doorStage = DoorStage.closing;
                audio_door.Play();
                animator.SetBool("Open", false);
                animator.SetBool("Close", true);
                _doorStage = DoorStage.closed;
                //_wallLogic.ClosedDoor();
            }
        }
	}
}
