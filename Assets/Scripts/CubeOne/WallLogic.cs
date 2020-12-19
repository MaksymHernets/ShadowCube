using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Cubes.CubeOne
{
    public class WallLogic : MonoBehaviour
    {
        private int indexwall = 0;

        public TextMesh number1;
        public TextMesh number2;

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
            string result = number.x.ToString() + " " + number.y.ToString() + " " + number.z.ToString();
            number1.text = result;
            number2.text = result;
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
            cube.SendMessage("EventOpenedDoor", (object)indexwall);
        }
    }
}
