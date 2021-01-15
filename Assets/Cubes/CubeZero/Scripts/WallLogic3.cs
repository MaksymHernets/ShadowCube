using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Cubes;

namespace Cubes.CubeZero
{
    public class WallLogic3 : MonoBehaviour
    {
        private Wall wall;

        public GameObject door;
        public TextMesh number1;

        public void IntWall(object cubee) // Wall
        {
            wall = (Wall)cubee;
            number1.text = string.Join(".", 
                GetSymbol(MathCube.SumNumber(wall.number.x)), 
                GetSymbol(MathCube.SumNumber(wall.number.y)), 
                GetSymbol(MathCube.SumNumber(wall.number.z)));
            gameObject.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", wall.color);
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
            transform.parent.gameObject.SendMessage("EventOpenedDoor", (object)wall.id);
        }
    }
}
