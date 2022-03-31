using UnityEngine;

namespace ShadowCube.Config
{
    [CreateAssetMenu(fileName = "CubesConfig", menuName = "ShadowCube/CubesConfig", order = 2)]
    public class CubesConfig : ScriptableObject
    {
        public string[] NameCubes;
    }
}
