using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.Player
{
	public class StageJump : MoveControlStage
	{
		private Vector3 vectorJump = Vector3.up;
		private float ForceJump = 150;
		private float groundDistance;
		private bool IsHook = false;

		private Coroutine coroutineJump;
		private Coroutine coroutineCheck;

		public StageJump(PlayerMoveControl player, Vector3 direction) : base(player)
		{
			vectorJump = direction;

			this._player.isJumping = true;
			this._player.Rigidbody.useGravity = true;
			this._player.cameraTarget.IsBind = false;

			_inputScheme.Forward.AddListener(Forward);

			_player.detectObject.EveneCollision += Handler_Detect;
		}

		public override void Start()
		{
			coroutineJump = _player.StartCoroutine(JumpAction());
			//coroutineCheck = _player.StartCoroutine(DetectCheckGround());
		}

		public override void Update()
		{
			
		}

		public override void Exit()
		{
			_inputScheme.Forward.RemoveListener(Forward);

			this._player.isJumping = false;
			_player.animator.SetBool("Jump", false);
			//_player.detectObject.EveneCollision -= Handler_Detect;
			//_player.StopCoroutine(coroutineCheck);
			Finish();
		}

		private IEnumerator DetectCheckGround()
		{
			yield return new WaitForSeconds(1f);
			while ( true )
			{
				_player.CheckGround();
				if (_player.isGrounded)
				{
					SetStage(new StageWalk(_player));
				}
				yield return new WaitForEndOfFrame();
			}
		}

		private IEnumerator JumpAction()
		{
			_player.animator.SetBool("Jump", true);
			yield return new WaitForEndOfFrame();
			yield return new WaitForSeconds(0.9f);
			_player.Rigidbody.AddForce(vectorJump * ForceJump, ForceMode.Acceleration);
			yield return new WaitForSeconds(1f);
			_player.animator.SetBool("Jump", false);
			yield return new WaitForEndOfFrame();
			_player.isJumping = false;
			SetStage(new StageFall(_player));
		}

		private void Handler_Detect(GameObject gameObject)
		{
			IsHook = gameObject.transform.tag == "hook";
		}

		public void Forward()
		{
			if ( IsHook )
			{
				SetStage( new StageFreeHang(_player) );
			}
		}
	}
}

