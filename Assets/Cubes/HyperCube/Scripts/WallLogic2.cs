using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Cubes.CubeHyber
{
    public class WallLogic2 : MonoBehaviour
    {
        private Wall wall;

        public GameObject door;

        public void IntWall(object cubee) // Wall
        {
            wall = (Wall)cubee;
        }

        public void ToOpenDoor()
        {
            door.SendMessage("MegaCubeToOpen");
        }

        public void OpenedDoor()
        {
            transform.parent.gameObject.SendMessage("EventOpenedDoor", (object)wall.id);
        }
    }
}
