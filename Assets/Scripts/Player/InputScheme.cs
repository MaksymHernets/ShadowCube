using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Player
{
	public class InputScheme
    {
        public UnityEvent Forward;
        public UnityEvent Back;
        public UnityEvent Left;
        public UnityEvent Right;
        public UnityAction<Vector2> Rotate;

        public UnityEvent Jump;
        public UnityEvent Sit;

        public UnityEvent Use;
        public UnityEvent OpenInventory;

        

        public InputScheme()
		{
            Forward = new UnityEvent();
            Back = new UnityEvent();
            Left = new UnityEvent();
            Right = new UnityEvent();

            Jump = new UnityEvent();
            Sit = new UnityEvent();

            Use = new UnityEvent();
            OpenInventory = new UnityEvent();
        }
    }
}
