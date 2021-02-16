using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace Cubes.CubeFour
{
    //  public class MegaCubeLogic1 : MonoBehaviour
    //  {
    //      public int _Size = 26;
    //      public float _WidhtCube = 2.4f;
    //      public GameObject prefabcube;

    //      public List<GameObject> Traps;
    //      public List<GameObject> Frames;

    //      private GameObject[] ActiveGamecubes;
    //      private CubeDTO[,,] begincubes;
    //      private CubeDTO[,,] cubes;
    //      private GameObject CubeBridge;
    //      private GameObject player;

    //      private int _Stage = 0;
    //      private float _TimeReposition = 120f;
    //      private float count = 0;

    //      void Start()
    //      {
    //          //_Size = Cookie.room.Size;
    //          //gamecubes = new GameObject[_Size, _Size, _Size];
    //          begincubes = new CubeDTO[_Size, _Size, _Size];
    //          cubes = new CubeDTO[_Size, _Size, _Size];

    //          SetFrames();
    //          SetCubes();
    //          //IntCubes();
    //          SetPlayers();

    //          //Set CubeDTO of Bridght
    //          //CubeBridge = SetCube(27, 26, 26);
    //      }

    //      private void Update()
    //      {
    //          count = Time.deltaTime;
    //          if ( _TimeReposition == count)
    //          {
    //              _Stage++;
    //              if (_Stage == 10) _Stage = 0;

    //              //foreach (var item in ActiveGamecubes)
    //              //{
    //                  //var cub = cubes[item.p]
    //                  //item.transform.position = NewPosition();
    //              //}
    //          }
    //      }

    //      #region Int
    //      public void IntPlayer(object objectPlayer)
    //{
    //          player = (GameObject)objectPlayer;
    //}

    //      private void SetFrames()
    //      {
    //          //var value = ((_Size / 2) + 1) * _WidhtCube;
    //          var value = _Size * _WidhtCube;
    //          Frames[0].transform.localPosition = new Vector3(0, -value, 0); // top
    //          Frames[1].transform.localPosition = new Vector3(0, 0, value); // left
    //          Frames[2].transform.localPosition = new Vector3(value, 0, 0);
    //          Frames[3].transform.localPosition = new Vector3(0, 0, -value); // right
    //          Frames[4].transform.localPosition = new Vector3(-value, 0, 0);
    //          Frames[5].transform.localPosition = new Vector3(0, value, 0); // down 
    //      }

    //      private void SetCubes()
    //      {
    //          for (int i = 0; i < _Size; ++i)
    //          {
    //              for (int j = 0; j < _Size; ++j)
    //              {
    //                  for (int l = 0; l < _Size; ++l)
    //                  {
    //                      var cubee = new CubeDTO();
    //                      cubee.Color = GetColor(Random.Range(0, 6));
    //                      cubee.id = new Vector3Int();
    //                      cubee.position = GenerateNumbers(cubee.id);
    //                      cubee.trap = SetTrap(cubee);

    //                      cubes[i, j, l] = cubee;
    //                  }
    //              }
    //          }
    //      }

    //      private Vector3Int GenerateNumbers(Vector3Int id)
    //      {
    //          return new Vector3Int(GenerateNumber(id.x), GenerateNumber(id.y), GenerateNumber(id.z));
    //      }

    //      private int GenerateNumber(int i)
    //      {
    //          int[] mass = new int[3];
    //          int last = 0;
    //          int x = 0;
    //          int index = 0;
    //          do
    //          {
    //              x = Random.Range(last, i);
    //              last = i - x;
    //              mass[index] = x;
    //          }
    //          while ( false );

    //          return SumNumbers(mass);
    //      }

    //      private int SumNumbers(int[] mass)
    //      {
    //          return 0;
    //      }

    //      private Vector3Int NewPosition(Vector3Int beginposition, Vector3Int shifr, int stage)
    //      {
    //          Vector3Int newposition = new Vector3Int();
    //          if ( stage == 0)
    //          {
    //              return beginposition;
    //          }
    //          else if ( stage == 1) // x1
    //          {
    //              var result = GetSubNumbers(shifr.x);
    //              int index = result[2] - result[1];
    //              return beginposition + new Vector3Int(index, 0, 0); 
    //          }
    //          else if (stage == 2) // y1
    //          {
    //              var result = GetSubNumbers(shifr.y);
    //              int index = result[2] - result[1];
    //              return beginposition + new Vector3Int(0, index, 0);
    //          }
    //          else if (stage == 3) // z1
    //          {
    //              var result = GetSubNumbers(shifr.z);
    //              int index = result[2] - result[1];
    //              return beginposition + new Vector3Int(0, 0, index);
    //          }
    //          else if (stage == 4) // x2
    //          {
    //              var result = GetSubNumbers(shifr.x);
    //              int index = result[1] - result[0];
    //              return beginposition + new Vector3Int(index, 0, 0);
    //          }
    //          else if (stage == 5) // y2
    //          {
    //              var result = GetSubNumbers(shifr.y);
    //              int index = result[1] - result[0];
    //              return beginposition + new Vector3Int(0, index, 0);
    //          }
    //          else if (stage == 6) // z2
    //          {
    //              var result = GetSubNumbers(shifr.z);
    //              int index = result[1] - result[0];
    //              return beginposition + new Vector3Int(0, 0, index);
    //          }
    //          else if (stage == 7) // x3
    //          {
    //              var result = GetSubNumbers(shifr.x);
    //              int index = result[0] - result[2];
    //              return beginposition + new Vector3Int(index, 0, 0);
    //          }
    //          else if (stage == 8) // y3
    //          {
    //              var result = GetSubNumbers(shifr.y);
    //              int index = result[0] - result[2];
    //              return beginposition + new Vector3Int(0, index, 0);
    //          }
    //          else if (stage == 9) // z3
    //          {
    //              var result = GetSubNumbers(shifr.z);
    //              int index = result[0] - result[2];
    //              return beginposition + new Vector3Int(0, 0, index);
    //          }


    //          return newposition;
    //      }

    //      private int[] GetSubNumbers(int number) // 225 % 100 - 5 / 10 = 
    //      {
    //          List<int> numbers = new List<int>();
    //          int t = 0;
    //          int last = 0;
    //          int index = 10;
    //          int index2 = 1;
    //          do
    //          {
    //              t = ((number - last) % index);
    //              if (index2 != 0){ t /= index2;  }
    //              last += t * index2;
    //              index *= 10;
    //              index2 *= 10;
    //              numbers.Add(t);

    //          }
    //          while ( (number - last) != 0);
    //          return numbers.ToArray();
    //      }

    //      private void IntCubes()
    //      {
    //          for (int i = 0; i < _Size; ++i)
    //          {
    //              for (int j = 0; j < _Size; ++j)
    //              {
    //                  for (int l = 0; l < _Size; ++l)
    //                  {
    //                      //cubes[i, j, l] 
    //                      //gamecubes[i, j, l] = IntCube(cubes[i, j, l]);
    //                      //if (cubes[i, j, l].trap != null)
    //                      //{
    //                      //    Instantiate(Traps[cubes[i, j, l].trap.id], gamecubes[i, j, l].transform);
    //                      //}
    //                  }
    //              }
    //          }
    //      }

    //      private GameObject IntCube(CubeDTO cubedto)
    //      {
    //          var newcube = Instantiate(prefabcube, transform);
    //          var newposition = NewPosition(cubedto.id, cubedto.position, _Stage);
    //          newcube.transform.position = new Vector3(newposition.x * _WidhtCube, newposition.y * _WidhtCube, newposition.z * _WidhtCube);
    //          newcube.SendMessage("IntCube", (object)cubedto);
    //          newcube.SetActive(false);
    //          return newcube;
    //      }

    //      private Trap SetTrap(CubeDTO cubedto)
    //      {
    //          if (MathCube.IsSimpleNumber(cubedto.shifr.x) || MathCube.IsSimpleNumber(cubedto.shifr.y) || MathCube.IsSimpleNumber(cubedto.shifr.z))
    //          {
    //              int index = Random.Range(0, Traps.Count);
    //              return new Trap() { id = index, name = Traps[index].name };
    //          }
    //          return null;
    //      }

    //      private void SetPlayers()
    //      {
    //          foreach (var item in Cookie.players)
    //          {
    //              int x = 0, y = 0, z = 0;
    //              do
    //              {
    //                  x = Random.Range(0, _Size);
    //                  y = Random.Range(0, _Size);
    //                  z = Random.Range(0, _Size);
    //              }
    //              while (cubes[x, y, z].trap != null);

    //              var newgamecube = IntCube(cubes[x, y, z]);
    //              newgamecube.transform.localPosition = NewPosition(cubes[x, y, z].position, cubes[x, y, z].shifr , _Stage);
    //              player.transform.localPosition = newgamecube.transform.localPosition;
    //              newgamecube.SetActive(true);
    //          }
    //      }

    //      private Color GetColor(int index)
    //      {
    //          if (index == 0) { return Color.white; }
    //          else if (index == 1) { return Color.red; }
    //          else if (index == 2) { return Color.yellow; }
    //          else if (index == 3) { return Color.blue; }
    //          else if (index == 4) { return Color.green; }
    //          else if (index == 5) { return Color.gray; }
    //          else if (index == 6) { return Color.magenta; }
    //          return Color.white;
    //      }
    //      #endregion

    //      #region Events
    //      public bool ActivateCube(Vector3Int oldposition, int oldwall, Vector3Int position, int wallnumber)
    //      {
    //          try
    //          {
    //              var actCube = cubes[position.x, position.y, position.z];
    //              //actCube.position = new Vector3Int();
    //              IntCube(actCube);
    //              //actCube.SetActive(true);
    //              //actCube.SendMessage("OpenDoor", wallnumber, SendMessageOptions.DontRequireReceiver);
    //          }
    //          catch
    //          {
    //              return false;
    //          }
    //          return true;
    //      }

    //      public void EventOpenedDoor(object vector4) // vector4 = position + indexwall
    //      {
    //          var result = (Vector4)vector4;
    //          var position = new Vector3Int((int)result.x, (int)result.y, (int)result.z);
    //          int indexwall = (int)result.w;
    //          var newposition = new Vector3Int(position.x, position.y, position.z);
    //          int newdoor = 0;


    //          newposition = GetCube(indexwall, position, out newdoor);
    //          ActivateCube(position, indexwall, newposition, newdoor);
    //      }

    //      public void EventClosedDoor(object vector4) // vector4 = position + indexwall
    //      {
    //          var result = (Vector4)vector4;
    //          var position = new Vector3Int((int)result.x, (int)result.y, (int)result.z);
    //          int indexwall = (int)result.w;
    //          var newposition = new Vector3Int(position.x, position.y, position.z);
    //          int newdoor = 0;


    //          newposition = GetCube(indexwall, position, out newdoor);
    //          newposition = NewPosition(cubes[newposition.x, newposition.y, newposition.z].position, cubes[newposition.x, newposition.y, newposition.z].shifr, _Stage);
    //          //ActivateCube(position, indexwall, newposition, newdoor);

    //      }

    //      private Vector3Int GetCube(int indexwall, Vector3Int position, out int newdoor)
    //      {
    //          Vector3Int newposition = new Vector3Int();
    //          newdoor = 0;
    //          if (indexwall == 0) { newposition = position + new Vector3Int(0, -1, 0); newdoor = 5; }
    //          else if (indexwall == 1) { newposition = position + new Vector3Int(0, 0, 1); newdoor = 3; }
    //          else if (indexwall == 2) { newposition = position + new Vector3Int(1, 0, 0); newdoor = 4; }
    //          else if (indexwall == 3) { newposition = position + new Vector3Int(0, 0, -1); newdoor = 1; }
    //          else if (indexwall == 4) { newposition = position + new Vector3Int(-1, 0, 0); newdoor = 2; }
    //          else if (indexwall == 5) { newposition = position + new Vector3Int(0, 1, 0); newdoor = 0; }
    //          return newposition;
    //      }

    //      public void DeactivateCube(object vector3) // vector3int
    //      {
    //          var position = (Vector3Int)vector3;
    //          Vector3Int newposition;
    //          int newdoor = 0;
    //          for (int i = 0; i < 6; ++i)
    //          {
    //              newposition = GetCube(i, position, out newdoor);
    //              CloseDoor(newposition, newdoor);
    //          }
    //      }

    //      private bool CloseDoor(Vector3Int position, int wallnumber)
    //      {
    //          try
    //          {
    //              if (position.x <= _Size && position.y <= _Size && position.z <= _Size)
    //              {
    //                  //var actCube = gamecubes[position.x, position.y, position.z];
    //                  //actCube.SendMessage("CloseDoor", wallnumber, SendMessageOptions.DontRequireReceiver);
    //              }
    //          }
    //          catch
    //          {
    //              return false;
    //          }
    //          return true;
    //      }

    //      #endregion
    //  }

    public class MegaCubeLogic5 : MonoBehaviour
    {
        public int _Size = 10;
        public float _WidhtCube = 2.6f;
        public GameObject prefabcube;

        public List<GameObject> Traps;
        public List<GameObject> Frames;

        private GameObject[,,] gamecubes;
        private CubeDTO[,,] cubes;
        private GameObject CubeBridge;
        private GameObject player;

        void Start()
        {
            _Size = Cookie.room.Size;
            gamecubes = new GameObject[_Size, _Size, _Size];
            cubes = new CubeDTO[_Size, _Size, _Size];

            SetFrames();
            SetCubes();
            IntCubes();
            SetPlayers();

            //Set CubeDTO of Bridght
            //SetCube(_Size+1, 5, 5);
        }

        #region Int
        public void IntPlayer(object player2)
        {
            player = (GameObject)player2;
        }

        private void SetFrames() 
        {
            var pol = _WidhtCube + _WidhtCube / 2;
            var longmed = ((_Size/2)+ pol) * _WidhtCube;
            var longtotal = ((_Size + 2) * _WidhtCube) + _WidhtCube / 2;
            Frames[0].transform.localPosition = new Vector3(0, -pol, 0); // top

            Frames[1].transform.localPosition = new Vector3(longtotal, 0, longmed); // left
            Frames[3].transform.localPosition = new Vector3(longmed, 0, -pol); // right

            Frames[2].transform.localPosition = new Vector3(longtotal, 0, longmed);
            Frames[4].transform.localPosition = new Vector3(-pol, 0, longmed);

            Frames[5].transform.localPosition = new Vector3(0, longtotal, 0); // down 
        }

        private void SetCubes()
        {
            for (int i = 0; i < _Size; ++i)
            {
                for (int j = 0; j < _Size; ++j)
                {
                    for (int l = 0; l < _Size; ++l)
                    {
                        var cubee = new CubeDTO();
                        cubee.Color = GetColor(Random.Range(0, 6));
                        cubee.id = new Vector3Int();
                        cubee.id.x = (int)Random.Range(300, 700);
                        cubee.id.y = (int)Random.Range(300, 700);
                        cubee.id.z = (int)Random.Range(300, 700);
                        cubee.position = new Vector3Int(i, j, l);
                        cubee.trap = SetTrap(cubee);

                        cubes[i, j, l] = cubee;
                    }
                }
            }
        }

        private void IntCubes()
        {
            for (int i = 0; i < _Size; ++i)
            {
                for (int j = 0; j < _Size; ++j)
                {
                    for (int l = 0; l < _Size; ++l)
                    {
                        gamecubes[i, j, l] = IntCube(cubes[i, j, l]);
                        if (cubes[i, j, l].trap != null)
                        {
                            Instantiate(Traps[cubes[i, j, l].trap.id], gamecubes[i, j, l].transform);
                        }
                    }
                }
            }
        }

        private GameObject IntCube(CubeDTO cubedto)
        {
            var newcube = Instantiate(prefabcube, transform);
            newcube.transform.position = new Vector3(cubedto.position.x * _WidhtCube, cubedto.position.y * _WidhtCube, cubedto.position.z * _WidhtCube);
            newcube.SendMessage("IntCube", (object)cubedto);
            //newcube.SendMessage("TransferParentToWall", (object)gameObject);
            newcube.SetActive(false);
            return newcube;
        }

        private Trap SetTrap(CubeDTO cubedto)
        {
            if (IsSimpleNumber(cubedto.id.x) || IsSimpleNumber(cubedto.id.y) || IsSimpleNumber(cubedto.id.z))
            {
                int index = Random.Range(0, Traps.Count - 1);
                return new Trap() { id = index, name = Traps[index].name };
            }
            return null;
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

        private Color GetColor(int index)
        {
            if (index == 0) { return Color.white; }
            else if (index == 1) { return Color.red; }
            else if (index == 2) { return Color.yellow; }
            else if (index == 3) { return Color.blue; }
            else if (index == 4) { return Color.green; }
            else if (index == 5) { return Color.cyan; }
            else if (index == 6) { return new Color(1f, 0.1f, 0f); }
            return Color.white;
        }
        #endregion

        #region Events
        bool IsSimpleNumber(int n)
        {
            if (n > 1)
            {
                for (int i = 2; i < n; ++i)
                    if (n % i == 0)
                        return false;
                return true;
            }
            else
                return false;
        }

        public bool ActivateCube(Vector3Int oldposition, int oldwall, Vector3Int position, int wallnumber)
        {
            try
            {
                var actCube = gamecubes[position.x, position.y, position.z];
                actCube.SetActive(true);
                actCube.SendMessage("OpenDoor", wallnumber, SendMessageOptions.DontRequireReceiver);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void EventOpenedDoor(object vector4) // vector4 = position + indexwall
        {
            var result = (Vector4)vector4;
            var position = new Vector3Int((int)result.x, (int)result.y, (int)result.z);
            int indexwall = (int)result.w;
            var newposition = new Vector3Int(position.x, position.y, position.z);
            int newdoor = 0;

            newposition = GetCube(indexwall, position, out newdoor);
            ActivateCube(position, indexwall, newposition, newdoor);
        }

        private Vector3Int GetCube(int indexwall, Vector3Int position, out int newdoor)
        {
            Vector3Int newposition = new Vector3Int();
            newdoor = 0;
            if (indexwall == 0) { newposition = position + new Vector3Int(0, -1, 0); newdoor = 5; }
            else if (indexwall == 1) { newposition = position + new Vector3Int(0, 0, 1); newdoor = 3; }
            else if (indexwall == 2) { newposition = position + new Vector3Int(1, 0, 0); newdoor = 4; }
            else if (indexwall == 3) { newposition = position + new Vector3Int(0, 0, -1); newdoor = 1; }
            else if (indexwall == 4) { newposition = position + new Vector3Int(-1, 0, 0); newdoor = 2; }
            else if (indexwall == 5) { newposition = position + new Vector3Int(0, 1, 0); newdoor = 0; }
            return newposition;
        }

        public void DeactivateCube(object vector3) // vector3int
        {
            var position = (Vector3Int)vector3;
            Vector3Int newposition;
            int newdoor = 0;
            for (int i = 0; i < 6; ++i)
            {
                newposition = GetCube(i, position, out newdoor);
                CloseDoor(newposition, newdoor);
            }
            gamecubes[position.x, position.y, position.z].SendMessage("Deactivate");
            //StartCoroutine("Wait", position);
        }

        private bool CloseDoor(Vector3Int position, int wallnumber)
        {
            try
            {
                var actCube = gamecubes[position.x, position.y, position.z];
                actCube.SendMessage("CloseDoor", wallnumber, SendMessageOptions.DontRequireReceiver);
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
