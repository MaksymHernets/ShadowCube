using ShadowCube.Cubes;
using ShadowCube.Helpers;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShadowCubeCubes.CubeFour
{
	public class MegaCubeLogic5 : MegaCubeLogic
    {
        [SerializeField] private List<GameObject> Frames;

        private int _Size = 10;

        private CubeLogic[,,] gamecubes;
        private CubeDTO[,,] cubes;
        
		public override void Init()
		{


            gamecubes = new CubeLogic[_Size, _Size, _Size];
            cubes = new CubeDTO[_Size, _Size, _Size];

            SetFrames();
            SetCubes();
            IntCubes();
            SetPlayers();

            //Set CubeDTO of Bridght
            //SetCube(_Size+1, 5, 5);

            base.Init();
		}

		#region Int

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

        private CubeLogic IntCube(CubeDTO cubedto)
        {
            var newcube = Instantiate(prefabCube, transform);
            newcube.transform.position = new Vector3(cubedto.position.x * _WidhtCube, cubedto.position.y * _WidhtCube, cubedto.position.z * _WidhtCube);
            newcube.IntCube(this, cubedto);
            newcube.gameObject.SetActive(false);
            return newcube;
        }

        private Trap SetTrap(CubeDTO cubedto)
        {
            if (MathFunction.IsSimpleNumber(cubedto.id.x) || MathFunction.IsSimpleNumber(cubedto.id.y) || MathFunction.IsSimpleNumber(cubedto.id.z))
            {
                int index = Random.Range(0, Traps.Count - 1);
                return new Trap() { id = index, name = Traps[index].name };
            }
            return null;
        }

        private void SetPlayers()
        {
            //foreach (var item in Cookie.players)
            //{
            //    int x = 0, y = 0, z = 0;
            //    do
            //    {
            //        x = Random.Range(0, _Size);
            //        y = Random.Range(0, _Size);
            //        z = Random.Range(0, _Size);
            //    }
            //    while (cubes[x, y, z].trap != null);
            //    player.transform.localPosition = gamecubes[x, y, z].transform.localPosition;
            //    gamecubes[x, y, z].gameObject.SetActive(true);
            //}
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

        public bool ActivateCube(Vector3Int oldposition, int oldwall, Vector3Int position, int wallnumber)
        {
            try
            {
                var actCube = gamecubes[position.x, position.y, position.z];
                actCube.gameObject.SetActive(true);
                actCube.OpenDoor(wallnumber);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override void EventOpenedDoor(Vector3Int position, int indexwall)
        {
            Vector3Int newposition = GetCube( position, indexwall );
            int newdoor = GetCubeDoor( position, indexwall );
            ActivateCube(position, indexwall, newposition, newdoor);
        }

        protected override Vector3Int GetCube(Vector3Int position, int indexWall)
        {
            if (indexWall == 0) { return position + new Vector3Int(0, -1, 0); }
            else if (indexWall == 1) { return position + new Vector3Int(0, 0, 1); }
            else if (indexWall == 2) { return position + new Vector3Int(1, 0, 0); }
            else if (indexWall == 3) { return position + new Vector3Int(0, 0, -1); }
            else if (indexWall == 4) { return position + new Vector3Int(-1, 0, 0); }
            else if (indexWall == 5) { return position + new Vector3Int(0, 1, 0); }
            return new Vector3Int();
        }

        protected override int GetCubeDoor(Vector3Int position, int indexWall)
        {
            if (indexWall == 0) { return 5; }
            else if (indexWall == 1) { return 3; }
            else if (indexWall == 2) { return 4; }
            else if (indexWall == 3) { return 1; }
            else if (indexWall == 4) { return 2; }
            else if (indexWall == 5) { return 0; }
            return 0;
        }

        public void DeactivateCube(Vector3Int position) 
        {
            Vector3Int newposition;
            int newdoor = 0;
            for (int i = 0; i < 6; ++i)
            {
                newposition = GetCube(position, i);
                newdoor = GetCubeDoor(position, i);
                CloseDoor(newposition, newdoor);
            }
            //gamecubes[position.x, position.y, position.z].DeacSendMessage("Deactivate");
        }

        private bool CloseDoor(Vector3Int position, int wallnumber)
        {
            try
            {
                var actCube = gamecubes[position.x, position.y, position.z];
                actCube.CloseDoor(wallnumber);
            }
            catch
            {
                return false;
            }
            return true;
        }

		protected override void UpdateMegaCube()
		{
			
		}

		public override void PutObject(Vector3Int position, Transform transform)
		{
			//throw new System.NotImplementedException();
		}


		#endregion
	}
}
