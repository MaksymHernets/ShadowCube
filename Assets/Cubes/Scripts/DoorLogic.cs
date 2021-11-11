using UnityEngine;

namespace ShadowCube.Cubes
{
	public abstract class DoorLogic : MonoBehaviour
    {
        protected WallLogic _wallLogic;
        protected DoorStage _doorStage = DoorStage.closed;

        public virtual void Init(WallLogic wallLogic)
		{
            _wallLogic = wallLogic;
        }

        public abstract void Open();
        public abstract void Close();

        public void OpenedDoor()
		{

		}
	}

    public interface IDoor
    {
        void Open();
        void Close();
    }

    public enum DoorStage
    {
        closed = 0,
        opening = 1,
        open = 2,
        closing = 3,
    }
}
