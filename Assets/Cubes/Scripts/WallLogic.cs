using UnityEngine;

namespace ShadowCube.Cubes
{
	[RequireComponent(typeof(MeshRenderer))]
    public abstract class WallLogic : MonoBehaviour
    {
        [SerializeField] private DoorLogic door;
        [SerializeField] private MeshRenderer meshRenderer;

        protected CubeLogic _cubeLogic;
        protected WallDTO _wall;

        public virtual void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            _cubeLogic = cubeLogic;
            _wall = wall;

            meshRenderer.materials[1].SetColor("_EmissionColor", wall.color);
            meshRenderer.materials[2].SetColor("_EmissionColor", wall.color);
        }
        
        public virtual void ToOpenDoor()
        {
            door.Open();
        }

        public virtual void ToCloseDoor()
        {
            door.Close();
        }

        public void OpenedDoor()
        {
            _cubeLogic.EventOpenedDoor(_wall.id);
        }

        public void ClosedDoor()
        {
            _cubeLogic.EventClosedDoor(_wall.id);
        }
    }

    public class WallDTO
    {
        public int id { set; get; }
        public Vector3Int number { set; get; }
        public Color color { set; get; }
    }
}
