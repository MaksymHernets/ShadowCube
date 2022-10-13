using UnityEngine;

namespace ShadowCube.Helpers
{
	public static class TransformExtension
    {
        public static void SwapTransform(GameObject a, GameObject b)
        {
            Vector3 temp = a.transform.position;
            a.transform.position = b.transform.position;
            b.transform.position = temp;
        }
    }
}
