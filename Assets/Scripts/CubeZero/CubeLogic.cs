using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeZero
{
    public class CubeLogic : MonoBehaviour
    {
        public CubeDTO cube;

        public List<Light> lights;
        public List<GameObject> walls;
        public GameObject megaCube;

        public void IntCube(object cubee) // Cube
        {
            cube = (CubeDTO)cubee;
            int index = 0;
            if (cube.trap != null)
            {
                var trap = Resources.Load<GameObject>("Prefabs/" + cube.trap.name);
                Instantiate(trap, transform);
            }
            foreach (var item in walls)
            {
                item.SendMessage("IntWall", (object)gameObject);
                item.SendMessage("IntWallIndex", (object)index);
                item.SendMessage("IntWallId", (object)cube.id);
                index++;
            }
            foreach (var light in lights)
            {
                light.color = cube.Color;
            }
        }

        public void IntCube2(object cubee) // Gameobject
        {
            megaCube = (GameObject)cubee;
        }

        public void OpenDoor(object indexDoor) // int
        {
            Debug.Log("OpenDoor");
            walls[(int)indexDoor].SendMessage("ToOpenDoor");
        }

        public void EventOpenedDoor(object indexwall) // int
        {
            var argument = new Vector4();
            argument.x = cube.position.x;
            argument.y = cube.position.y;
            argument.z = cube.position.z;
            argument.w = (int)indexwall;
            //var megacube = GameObject.FindGameObjectWithTag("MegaCube");
            Debug.Log("EventOpenedDoor");
            megaCube.SendMessage("EventOpenedDoor", (object)argument);
        }
    }
}
