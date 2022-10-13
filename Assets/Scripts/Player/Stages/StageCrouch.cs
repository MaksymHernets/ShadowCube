using System.Collections;
using UnityEngine;

namespace ShadowCube.Player
{
	public class StageCrouch : MoveControlStage
	{
		private bool IsTop = false;

		public StageCrouch(PlayerMoveControl player) : base(player)
		{
			this._player.Rigidbody.velocity = Vector3.zero;
			this._player.Rigidbody.useGravity = true;
			this._player.isClimb = false;
			this._player.isFreeHang = false;
			this._player.cameraTarget.IsBind = true;
			this._player.capsuleCollider.height = 0.9f;
			this._player.capsuleCollider.center = new Vector3(0, 0.475f, 0);
			player.animator.SetBool("Crouch", true);

			_inputScheme.Forward.AddListener(Forward);
			_inputScheme.Back.AddListener(Back);
			_inputScheme.Left.AddListener(Left);
			_inputScheme.Right.AddListener(Right);

			_inputScheme.Sit.AddListener(SitDown);

			_inputScheme.Rotate += Rotate;
		}

		public override void Update()
		{
			float dist = _player.CheckDistance(Vector3.up);
			IsTop = dist < 1;
		}

		public override void Exit()
		{
			_inputScheme.Forward.RemoveListener(Forward);
			_inputScheme.Back.RemoveListener(Back);
			_inputScheme.Left.RemoveListener(Left);
			_inputScheme.Right.RemoveListener(Right);

			_inputScheme.Sit.RemoveListener(SitDown);
			_inputScheme.Rotate -= Rotate;
			Finish();
		}

		public void Back()
		{
			if (!_player.isGrounded) return;
			_player.MoveCharacter(-_player.transform.forward);
		}

		public void Forward()
		{
			if (!_player.isGrounded) return;
			_player.MoveCharacter(_player.transform.forward);
		}

		public void Left()
		{
			if (!_player.isGrounded) return;
			_player.MoveCharacter(-_player.transform.right);
		}

		public void Right()
		{
			if (!_player.isGrounded) return;
			_player.MoveCharacter(_player.transform.right);
		}

		public void Rotate(Vector2 position)
		{
			if (!_player.isGrounded) return;
			_player.transform.localEulerAngles += new Vector3(0, position.y, 0);
		}

		public void SitDown()
		{
			if (IsTop) return;
			this._player.capsuleCollider.height = 1.9f;
			this._player.capsuleCollider.center = new Vector3(0, 0.95f, 0);
			_player.animator.SetBool("Crouch", false);
			_player.StartCoroutine(SitUp());
		}

		private IEnumerator SitUp()
		{
			_player.isSitDown = false;
			_player.animator.SetBool("Crouch", false);
			yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds(1.5f);
			SetStage( new StageWalk(_player) );
		}
	}
}
