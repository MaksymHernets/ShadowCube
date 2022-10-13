using UnityEngine;

namespace ShadowCube.Player
{
	public class StageFreeHang : MoveControlStage
	{

		public StageFreeHang(PlayerMoveControl player) : base (player)
		{
			_player.Rigidbody.velocity = Vector3.zero;
			_player.Rigidbody.useGravity = false;
			_player.isFreeHang = true;
			_player.cameraTarget.IsBind = false;
			_player.animator.SetBool("FreeHang", true);

			_inputScheme.Forward.AddListener(Forward);
			_inputScheme.Back.AddListener(Back);
			_inputScheme.Left.AddListener(Left);
			_inputScheme.Right.AddListener(Right);
		}

		public override void Start()
		{
			_player.animator.SetBool("FreeHang", true);
		}

		public override void Exit()
		{
			_inputScheme.Forward.RemoveListener(Forward);
			_inputScheme.Back.RemoveListener(Back);
			_inputScheme.Left.RemoveListener(Left);
			_inputScheme.Right.RemoveListener(Right);

			_player.animator.SetBool("FreeHang", false);
			_player.isFreeHang = false;
			Finish();
		}

		public void Back()
		{
			SetStage(new StageWalk(_player), 1f);
		}

		public void Forward()
		{
			SetStage(new StageHang(_player), 1f);
		}

		public void Left()
		{
			_player.MoveCharacter(-_player.transform.right);
		}

		public void Right()
		{
			_player.MoveCharacter(_player.transform.right);
		}
	}
}
