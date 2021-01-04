using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes
{
    public class WallLogic : MonoBehaviour
    {
        protected Wall wall;

        public GameObject door;

        public void IntWall(object _object) // Wall
        {
            wall = (Wall)_object;
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
        
    }

    interface IWallLogic
    {

    }
}
