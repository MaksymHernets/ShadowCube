using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Cubes.CubeHyber
{
    public class MegaCubeLogic : MonoBehaviour
    {
        public List<GameObject> frames;
        public GameObject player;

        public int _Size = 10;
        public float _WidhtCube = 2.4f;

        public GameObject prefabcube;
        private GameObject[,,] gamecubes;
        private Cube[,,] cubes;

        void Start()
        {
            //SetFrames();
            SetCubes();
            SetPlayers();
        }

        public void IntPlayer(object player2)
        {
            player = (GameObject)player2;
        }

        private void SetFrames()
        {
            var value = ((_Size / 2) + 1) * _WidhtCube * 5;
            frames[0].transform.position = new Vector3(0, value, 0);
            frames[1].transform.position = new Vector3(0, 0, value);
            frames[2].transform.position = new Vector3(0, 0, -value);
            frames[3].transform.position = new Vector3(value, 0, 0);
            frames[4].transform.position = new Vector3(-value, 0, 0);
            frames[5].transform.position = new Vector3(0, -value, 0);
        }

        private void SetCubes()
        {
            _Size = Cookie.room.Size;
            gamecubes = new GameObject[_Size, _Size, _Size];
            cubes = new Cube[_Size, _Size, _Size];
            for (int i = 0; i < _Size; ++i)
            {
                for (int j = 0; j < _Size; ++j)
                {
                    for (int l = 0; l < _Size; ++l)
                    {
                        SetCube(i, j, l);
                    }
                }
            }

            void SetCube(int i, int j, int l)
            {
                var newcube = Instantiate(prefabcube, transform);
                newcube.transform.position = new Vector3(i * _WidhtCube, j * _WidhtCube, l * _WidhtCube);
                var cubee = new Cube();
                cubee.Color = Color.white;
                cubee.id = new Vector3Int();
                cubee.id.x = (int)Random.Range(300, 700);
                cubee.id.y = (int)Random.Range(300, 700);
                cubee.id.z = (int)Random.Range(300, 700);
                cubee.position = new Vector3Int(i, j, l);
                gamecubes[i, j, l] = newcube;
                cubes[i, j, l] = cubee;
                newcube.SendMessage("IntCube", (object)cubee);
                newcube.SendMessage("IntCube2", (object)gameObject);
                newcube.SetActive(false);
            }
        }

        private void SetPlayers()
        {
            foreach (var item in Cookie.players)
            {
                int x = 0, y = 0, z = 0;
                do
                {
                    x = Random.Range(0, _Size);
                    y = Random.Range(0, _Size);
                    z = Random.Range(0, _Size);
                }
                while (cubes[x, y, z].trap != null);
                player.transform.localPosition = gamecubes[x, y, z].transform.localPosition;
                gamecubes[x, y, z].SetActive(true);
            }
        }

        public bool ActivateCube(Vector3Int oldposition, int oldwall, Vector3Int position, int wallnumber)
        {
            try
            {
                var actCube = gamecubes[position.x, position.y, position.z];
                actCube.SetActive(true);
                actCube.SendMessage("OpenDoor", wallnumber);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void EventOpenedDoor(object vector4) // vector4 = position + indexwall
        {
            Debug.Log("MegaCUve");
            var result = (Vector4)vector4;
            var position = new Vector3Int((int)result.x, (int)result.y, (int)result.z);
            int indexwall = (int)result.w;
            var newposition = new Vector3Int(position.x, position.y, position.z);
            int newdoor = 0;

            Debug.Log(indexwall);
            if (indexwall == 0) { newposition += new Vector3Int(0, -1, 0); newdoor = 5; }
            else if (indexwall == 1) { newposition += new Vector3Int(0, 0, 1); newdoor = 3; }
            else if (indexwall == 2) { newposition += new Vector3Int(1, 0, 0); newdoor = 4; }
            else if (indexwall == 3) { newposition += new Vector3Int(0, 0, -1); newdoor = 1; }
            else if (indexwall == 4) { newposition += new Vector3Int(-1, 0, 0); newdoor = 2; }
            else if (indexwall == 5) { newposition += new Vector3Int(0, 1, 0); newdoor = 0; }
            ActivateCube(position, indexwall, newposition, newdoor);
        }
    }
}
