using ShadowCube.Helpers;
using ShadowCube.Player;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.Cubes
{
	public abstract class MegaCubeLogic : MonoBehaviour
    {
        [SerializeField] protected CubeLogic prefabCube;
		[SerializeField] protected PoolObjects<CubeLogic> poolObjects;
		[SerializeField] protected List<GameObject> Traps;
        [SerializeField] protected GameObject CubeBridge;
        [SerializeField] protected PlayerLogic player;

		protected float _WidhtCube = 2.6f;

		private void Update()
		{
			UpdateMegaCube();
		}

		public virtual void Init()
		{
			poolObjects = new PoolObjects<CubeLogic>(prefabCube);
		}

		public abstract void EventOpenedDoor(Vector3Int position, int indexDoor);
		protected abstract Vector3Int GetCube(Vector3Int position, int indexWall);
		protected abstract int GetCubeDoor(Vector3Int position, int indexWall);
		public virtual void PutObject(Vector3Int position, Transform transform)
		{
			CubeLogic currentCube = ActivateCube(position);
			transform.localPosition = currentCube.transform.localPosition;
		}
		public abstract CubeLogic ActivateCube(Vector3Int position, int wallnumber = 6);
		protected abstract void UpdateMegaCube();
	}
}
