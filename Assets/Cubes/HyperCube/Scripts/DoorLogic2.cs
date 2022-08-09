using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeHyber
{
	public class DoorLogic2 : DoorLogic
    {
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject doorLeft;
        [SerializeField] private GameObject doorRight;

        [SerializeField] private AudioSource audioDoor;

        public override void Open()
        {
            if (_doorStage == DoorStage.closed)
            {
                _doorStage = DoorStage.opening;
                audioDoor.Play();
                //doorLeft.transform.DOLocalMove(doorLeft.transform.localPosition + new Vector3(0, 0, -0.2f), 3f);
                //doorRight.transform.DOLocalMove(doorRight.transform.localPosition + new Vector3(0, 0, 0.2f), 3f);
                animator.SetBool("Close", false);
                animator.SetBool("Open", true);
                _doorStage = DoorStage.open;
            }
        }

        public override void Close()
        {
            if (_doorStage == DoorStage.open || _doorStage == DoorStage.opening)
            {
                animator.SetBool("Close", true);
                animator.SetBool("Open", false);
                _doorStage = DoorStage.closing;
                _doorStage = DoorStage.closed;
            }
        }
	}
}
