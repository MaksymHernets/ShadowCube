using ShadowCube.Helpers;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Player
{
	public abstract class MoveControlStage : BaseStage
    {
        protected PlayerMoveControl _player;
        protected InputScheme _inputScheme => _player.InputScheme;

        protected bool IsExiting = false;

        public MoveControlStage(PlayerMoveControl player)
		{
            IsExiting = false;
            _player = player;
        }

        public void SetStage(BaseStage stage)
		{
            IsExiting = true;
            _player.stageMachine.SetStage(stage);
        }

        public void SetStage(BaseStage stage, float time )
        {
            IsExiting = true;
            _player.StartCoroutine(WaitTime(stage, time));
        }

        private IEnumerator WaitTime(BaseStage stage, float time)
		{
            yield return new WaitForSeconds(time);
            _player.stageMachine.SetStage(stage);
        }
    }

    public interface IMoveControl
	{
        void Forward();
        void Left();
        void Right();
        void Back();
        void Rotate(Vector2 vector2);
        void Move(Vector3 direction);
    }

    public interface IActionControl
	{
        void Jump();
        void Sit();
    }
}
