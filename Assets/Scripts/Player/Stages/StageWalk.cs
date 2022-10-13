using UnityEngine;

namespace ShadowCube.Player
{
	public class StageWalk : MoveControlStage
	{
		private bool IsForward = false;
		private bool IsTurn = false;

		private float groundMinDistance = 0.02f;

		public StageWalk(PlayerMoveControl player) : base(player)
		{
			this._player.Rigidbody.velocity = Vector3.zero;
			this._player.Rigidbody.useGravity = true;
			this._player.cameraTarget.IsBind = true;

			//player.detectObject.EveneCollision += Handler_Detect;

			_inputScheme.Forward.AddListener(Forward);
			_inputScheme.Back.AddListener(Back);
			_inputScheme.Left.AddListener(Left);
			_inputScheme.Right.AddListener(Right);

			_inputScheme.Jump.AddListener(Jump);
			_inputScheme.Sit.AddListener(Sit);

			_inputScheme.Rotate += Rotate;
		}

		public override void Start()
		{
			this._player.animator.Play("Idle");
		}

		public override void Update()
		{
			if ( !IsForward ) _player.animator.SetFloat("Walk", -Time.deltaTime);
			if ( !IsTurn )
			{
				_player.animator.SetBool("LeftTurn", false);
				_player.animator.SetBool("RightTurn", false);
			}
			IsForward = false;
			IsTurn = false;

			_player.isGrounded = CheckGround();
			if ( !_player.isGrounded )
			{
				SetStage(new StageFall(_player));
			}
		}

		public override void Exit()
		{
			_inputScheme.Forward.RemoveListener(Forward);
			_inputScheme.Back.RemoveListener(Back);
			_inputScheme.Left.RemoveListener(Left);
			_inputScheme.Right.RemoveListener(Right);

			_inputScheme.Jump.RemoveListener(Jump);
			_inputScheme.Sit.RemoveListener(Sit);

			_inputScheme.Rotate -= Rotate;
			//_player.detectObject.EveneCollision -= Handler_Detect;

			_player.animator.SetBool("LeftTurn", false);
			_player.animator.SetBool("RightTurn", false);
			_player.animator.SetFloat("Walk", 0);
			Finish();
		}

		private void Handler_Detect(GameObject gameObject)
		{
			if (gameObject.transform.tag == "ladder")
			{
				SetStage( new StageClimb(_player ) );
			}
		}

		public void Back()
		{
			_player.MoveCharacter(-_player.transform.forward);
		}

		public void Forward()
		{
			IsForward = true;
			float walk = _player.animator.GetFloat("Walk");
			_player.animator.SetFloat("Walk", walk + Time.deltaTime);
			_player.MoveCharacter(_player.transform.forward);

			if (CheckLadder()) SetStage(new StageClimb(_player));
		}

		public void Left()
		{
			//player.animator.SetBool("LeftTurn", true);
			_player.MoveCharacter(-_player.transform.right);
		}

		public void Right()
		{
			//player.animator.SetBool("RightTurn", true);
			_player.MoveCharacter(_player.transform.right);
		}

		public void Sit()
		{
			SetStage( new StageCrouch(_player) );
			_player.isSitDown = true;
		}

		public void Rotate(Vector2 position)
		{
			if ( position.y > 0.5 )
			{
				_player.animator.SetBool("RightTurn", true);
				IsTurn = true;
			}
			else if(position.y < -0.5)
			{
				_player.animator.SetBool("LeftTurn", true);
				IsTurn = true;
			}
			_player.transform.localEulerAngles += new Vector3(0, position.y, 0);
		}

		public void Jump()
		{
			SetStage( new StageJump(_player, Vector3.up) );
		}

		private bool CheckGround()
		{
			float dist = _player.CheckDistance(-Vector3.up) - (_player.capsuleCollider.height / 2);
			return dist < groundMinDistance;
		}

		private bool CheckLadder()
		{
			float dist = _player.CheckDistance(Vector3.forward, 9);
			return dist < 0.2;
		}
	}
}
