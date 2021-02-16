using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeZero
{
    public class CubeLogic3 : MonoBehaviour
    {
        private CubeDTO cube;

        public Light lightt;
        public List<GameObject> walls;

        public void IntCube(object cubee) // CubeDTO
        {
            cube = (CubeDTO)cubee;
            int index = 0;
            foreach (var item in walls)
            {
                item.SendMessage("IntWall", new Wall() { id = index, number = cube .id , color = cube.Color});
                index++;
            }
            lightt.color = cube.Color;
        }

        public void OpenDoor(object indexDoor) // int
        {
            walls[(int)indexDoor].SendMessage("ToOpenDoor");
        }

        public void EventOpenedDoor(object indexwall) // int
        {
            var argument = new Vector4();
            argument.x = cube.position.x;
            argument.y = cube.position.y;
            argument.z = cube.position.z;
            argument.w = (int)indexwall;
            transform.parent.gameObject.SendMessage("EventOpenedDoor", (object)argument);
        }
    }
}
