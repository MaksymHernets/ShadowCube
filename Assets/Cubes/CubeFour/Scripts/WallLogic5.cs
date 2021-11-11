using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeFour
{
	public class WallLogic5 : WallLogic
    {      
        [SerializeField] private TextMesh number;

        public override void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            base.IntWall(cubeLogic, wall);
            number.text = _wall.number.x.ToString() + " " + _wall.number.y.ToString() + " " + _wall.number.z.ToString();
        }
    }
}
