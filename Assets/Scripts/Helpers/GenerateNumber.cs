using System.Text;
using UnityEngine;

namespace ShadowCube.Helpers
{
	public static class GenerateNumber
    {
        public static string GetCode(int length)
		{
            StringBuilder result = new StringBuilder(length);
            result.Length = length;
            for (int i = 0; i < length; ++i)
            {
                result[i] = (char)Random.Range(65, 90);
            }
            return result.ToString();
        }
    }
}
