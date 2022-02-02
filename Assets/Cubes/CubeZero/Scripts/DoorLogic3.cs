using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeZero
{
    public class DoorLogic3 : DoorLogic
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AudioSource audio_door;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audio_door.Play();
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                _doorStage = DoorStage.open;
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open || _doorStage == DoorStage.opening)
            {
                _doorStage = DoorStage.closing;
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                _doorStage = DoorStage.closed;
            }
        }
    }
}
