using UnityEngine;

namespace Cubes.CubeNew
{
	public class WallLogic4 : WallLogic
    {
        [SerializeField] private TextMesh number;

        public override void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            base.IntWall(cubeLogic, wall);
            number.text = string.Join(".",
                GetRomeNumber(MathFunction.SumNumber(wall.number.x)),
                GetRomeNumber(MathFunction.SumNumber(wall.number.y)),
                GetRomeNumber(MathFunction.SumNumber(wall.number.z)));
        }

        private string GetRomeNumber(int number)
        {
            string result = string.Empty;
            if (number <= 10)
            {
                result = GetRome(number);
            }
            else if (number <= 20)
            {
                result = "X" + GetRome(number-10);
            }
            else if (number <= 30)
            {
                result = "XX" + GetRome(number - 20);
            }
            else if (number <= 40)
            {
                result = "XXX" + GetRome(number - 30);
            }

            return result;
        }

        private string GetRome(int index)
        {
            if ( index <= 3)
            {
                return RM(index);
            }
            else if (index == 4)
            {
                return "IV";
            }
            else if (index == 5)
            {
                return "V";
            }
            else if (index <= 8)
            {
                return "V" + RM(index-5);
            }
            else if (index == 9)
            {
                return "IX";
            }
            else if (index == 10)
            {
                return "X";
            }


            string RM(int indexx)
            {
                string result = string.Empty;
                for (int i = 0; i < indexx; i++)
                {
                    result += "I";
                }
                return result;
            }

            return "";

        }
    }
}
