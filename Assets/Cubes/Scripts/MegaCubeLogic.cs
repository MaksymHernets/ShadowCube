using System.Collections.Generic;
using UnityEngine;

namespace Cubes
{
	public abstract class MegaCubeLogic : MonoBehaviour
    {
        [SerializeField] protected CubeLogic prefabCube;
		[SerializeField] protected PoolObjects<CubeLogic> poolObjects;
		[SerializeField] protected List<GameObject> Traps;
        [SerializeField] protected GameObject CubeBridge;
        [SerializeField] protected PlayerLogic player;
		
		private void Start()
		{
			Init();
		}

		private void Update()
		{
			UpdateMegaCube();
		}

		protected virtual void Init()
		{
			poolObjects = new PoolObjects<CubeLogic>(prefabCube);
		}

		public abstract void EventOpenedDoor(Vector3Int position, int indexDoor);
		public abstract Vector3Int GetCube(Vector3Int position, int indexWall);
		public abstract int GetCubeDoor(Vector3Int position, int indexWall);
		protected abstract void UpdateMegaCube();

		
	}
}
