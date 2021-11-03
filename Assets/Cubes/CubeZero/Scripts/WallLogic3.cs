using UnityEngine;

namespace Cubes.CubeZero
{
	public class WallLogic3 : WallLogic
    {
        [SerializeField] private TextMesh number;

        public override void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            base.IntWall(cubeLogic, wall);

            number.text = string.Join(".", 
                GetSymbol(MathCube.SumNumber(wall.number.x)), 
                GetSymbol(MathCube.SumNumber(wall.number.y)), 
                GetSymbol(MathCube.SumNumber(wall.number.z)));
        }

        private string GetSymbol(int index)
        {
            return char.ConvertFromUtf32(65 + index);
        }
    }
}
