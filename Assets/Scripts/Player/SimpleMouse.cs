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
            float translationX = Input.GetAxis("Vertical") * scale;
            float translationY = Input.GetAxis("Horizontal") * scale;
            return new Vector2(translationX, translationY);
        }
    }
}
