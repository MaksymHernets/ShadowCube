using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
    public static class SimpleMouse
    {
        public static float scale = 1f;

        public static Vector2 GetPosition()
        {
            float translationX = Input.GetAxis("Mouse X") * scale;
            float translationY = Input.GetAxis("Mouse Y") * scale;
            return new Vector2(translationY, translationX);
        }
    }
}
