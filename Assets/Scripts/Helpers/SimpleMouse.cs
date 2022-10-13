using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
    public static class SimpleMouse
    {
        private static float Scale = 130f;

        public static Vector2 GetPosition()
		{
            float X = Input.GetAxis("Mouse X") * Time.deltaTime;
            float Y = -Input.GetAxis("Mouse Y") * Time.deltaTime;
            return new Vector2(Y * Scale, X * Scale);
        }
    }
}
