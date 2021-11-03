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
                GetSymbol(MathFunction.SumNumber(wall.number.x)), 
                GetSymbol(MathFunction.SumNumber(wall.number.y)), 
                GetSymbol(MathFunction.SumNumber(wall.number.z)));
        }

        private string GetSymbol(int index)
        {
            return char.ConvertFromUtf32(65 + index);
        }
    }
}
