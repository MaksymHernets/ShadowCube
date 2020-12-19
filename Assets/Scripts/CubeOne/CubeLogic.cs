using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeOne
{
    public class CubeLogic : MonoBehaviour
    {
        private int CountPlayers = 0;
        private float TimeWait = 10;
        private float TimeLost = 0;

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
            walls[(int)indexDoor].SendMessage("ToOpenDoor");
        }

        public void CloseDoor(object indexDoor) // int
        {
            walls[(int)indexDoor].SendMessage("ToCloseDoor");
        }

        private void CloseAllDoor()
        {
            foreach (var item in walls)
            {
                item.SendMessage("ToCloseDoor");
            }
        }

        public void EventOpenedDoor(object indexwall) // int
        {
            var argument = new Vector4();
            argument.x = cube.position.x;
            argument.y = cube.position.y;
            argument.z = cube.position.z;
            argument.w = (int)indexwall;
            megaCube.SendMessage("EventOpenedDoor", (object)argument);
        }

        private void OnTriggerEnter(Collider collision)
        {
            ++CountPlayers;
        }

        private void OnTriggerExit(Collider collision)
        {
            --CountPlayers;
            //Debug.Log(CountPlayers.ToString());
            if (CountPlayers == 0) // Закрываем куб
            {
                TimeLost = 0;
            }
        }

        public void Update()
        {
            TimeLost += Time.deltaTime;
            if (CountPlayers == 0 && TimeWait <= TimeLost)
            {
                TimeLost = 0;
                var argument = new Vector3Int();
                argument.x = cube.position.x;
                argument.y = cube.position.y;
                argument.z = cube.position.z;
                megaCube.SendMessage("DeactivateCube", (object)argument);
                CloseAllDoor();
                gameObject.SetActive(false);
            }
        }

    }
}
