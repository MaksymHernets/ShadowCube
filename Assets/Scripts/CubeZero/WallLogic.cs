using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Cubes.CubeZero
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
            var result = string.Join(".", GetSymbol(GetSum(number.x)), GetSymbol(GetSum(number.y)), GetSymbol(GetSum(number.z)));
            number1.text = result;
            number2.text = result;
        }

        private int GetSum(int value)
        {
            int value1 = value % 10;
            int value2 = ((value % 100) - value1)/10;
            int value3 = ((value % 1000) - value2) / 100;
            return value1 + value2 + value3;
        }

        private string GetSymbol(int index)
        {
            return char.ConvertFromUtf32(65 + index);
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
