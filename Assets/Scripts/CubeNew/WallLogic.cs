using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Cubes.CubeNew
{
    public class WallLogic : MonoBehaviour
    {
        private int indexwall = 0;

        public GameObject cube;
        public GameObject door;

        public void IntWall(object cubee) // Gameobject
        {
            cube = (GameObject)cubee;
        }

        public void IntWallIndex(object index) // index
        {
            indexwall = (int)index;
        }

        public void IntWallId(object index) // index
        {
            var number = (Vector3Int)index;
        }

        public void ToOpenDoor()
        {
            door.SendMessage("MegaCubeToOpen");
        }

        public void OpenedDoor()
        {
            cube.SendMessage("EventOpenedDoor", (object)indexwall);
        }
    }
}
