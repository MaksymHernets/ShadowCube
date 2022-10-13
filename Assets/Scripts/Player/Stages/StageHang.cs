using UnityEngine;

namespace ShadowCube.Player
{
	public class StageHang : MoveControlStage
	{
		public StageHang(PlayerMoveControl player) : base(player)
		{
			this._player.Rigidbody.velocity = Vector3.zero;
			this._player.Rigidbody.useGravity = false;
			this._player.isFreeHang = true;
			this._player.cameraTarget.IsBind = false;

			_inputScheme.Forward.AddListener(Forward);
			_inputScheme.Back.AddListener(Back);
			_inputScheme.Jump.AddListener(Jump);
		}

		public override void Start()
		{
			_player.animator.SetBool("Hang", true);
		}

		public override void Exit()
		{
			_inputScheme.Forward.RemoveListener(Forward);
			_inputScheme.Jump.RemoveListener(Jump);
			_inputScheme.Back.RemoveListener(Back);

			_player.animator.SetBool("Hang", false);
			_player.isFreeHang = false;
			Finish();
		}

		public void Jump()
		{
			SetStage(new StageJump(_player, -_player.transform.forward));
		}

		public void Back()
		{
			SetStage(new StageFreeHang(_player));
		}

		public void Forward()
		{
			SetStage(new StageFreeHang(_player));
		}
	}
}
