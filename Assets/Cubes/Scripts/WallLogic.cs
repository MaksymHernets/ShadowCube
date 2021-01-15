using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Cubes
{
    public class WallLogic : MonoBehaviour
    {
        protected Wall wall;
        //public MeshRenderer renderer;

        public GameObject door;

        public void IntWall(object _object) // Wall
        {
            wall = (Wall)_object;
            gameObject.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", wall.color);
            gameObject.GetComponent<MeshRenderer>().materials[2].SetColor("_EmissionColor", wall.color);
        }
        
        public void ToOpenDoor()
        {
            door.SendMessage("MegaCubeToOpen");
        }

        public void ToCloseDoor()
        {
            door.SendMessage("MegaCubeToClose");
        }

        public void OpenedDoor()
        {
            transform.parent.gameObject.SendMessage("EventOpenedDoor", (object)wall.id);
        }

        public void ClosedDoor()
        {
            transform.parent.gameObject.SendMessage("EventClosedDoor", (object)wall.id);
        }
    }

    public class Wall
    {
        public int id { set; get; }

        public Vector3Int number { set; get; }

        public Color color { set; get; }

    }

    interface IWallLogic
    {

    }
}
