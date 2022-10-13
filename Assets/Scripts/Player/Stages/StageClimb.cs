using UnityEngine;

namespace ShadowCube.Player
{
	public class StageClimb : MoveControlStage
	{
		public StageClimb(PlayerMoveControl player) : base(player)
		{
			this._player.Rigidbody.velocity = Vector3.zero;
			this._player.Rigidbody.useGravity = false;
			this._player.isClimb = true;
			this._player.cameraTarget.IsBind = false;
			this._player.cameraTarget.ShiftX = this._player.transform.localEulerAngles.y;

			player.detectObject.EveneCollisionExit += Handler_DetectExit;

			_inputScheme.Forward.AddListener(Forward);
			_inputScheme.Back.AddListener(Back);
			_inputScheme.Left.AddListener(Left);
			_inputScheme.Right.AddListener(Right);

			_inputScheme.Jump.AddListener(Jump);
		}

		public override void Start()
		{
			_player.animator.SetBool("ClimbUp", true);
		}

		public override void Exit()
		{
			_player.animator.SetBool("ClimbUp", false);
			_player.isClimb = false;
			_player.detectObject.EveneCollisionExit -= Handler_DetectExit;
			Finish();
		}

		private void Handler_DetectExit(GameObject gameObject)
		{
			if (gameObject.transform.tag == "ladder")
			{
				SetStage(new StageWalk(_player));
			}
			else
			{
				return;
			}
			_player.detectObject.EveneCollisionExit -= Handler_DetectExit;
		}

		public void Jump()
		{
			_player.Rigidbody.AddForce(-_player.transform.forward * 500, ForceMode.Acceleration);
		}

		public void Back()
		{
			_player.MoveCharacter(-_player.transform.up);
		}

		public void Forward()
		{
			_player.MoveCharacter(_player.transform.up);
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
