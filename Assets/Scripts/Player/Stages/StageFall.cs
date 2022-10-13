using UnityEngine;

namespace ShadowCube.Player
{
	public class StageFall : MoveControlStage
	{
		private float groundMinDistance = 0.05f;

		public StageFall(PlayerMoveControl player) : base(player)
		{
			_player.Rigidbody.velocity = Vector3.zero;
			_player.Rigidbody.useGravity = true;
			_player.cameraTarget.IsBind = false;
		}

		public override void Start()
		{
			_player.animator.SetBool("Fall", true);
			_player.animator.Play("JumpingDown");
		}

		public override void Update()
		{
			float dist = _player.CheckDistance(-Vector3.up) - (_player.capsuleCollider.height / 2);
			_player.isGrounded = dist > groundMinDistance;
			if (!_player.isGrounded)
			{
				SetStage(new StageWalk(_player));
			}
		}

		public override void Exit()
		{
			_player.animator.SetBool("Fall", false);
			Finish();
		}
	}
}

