using ShadowCube.Cubes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowCubeCubes.CubeOne
{
    public class WallLogic1 : WallLogic
    {      
        [SerializeField] private TextMesh number;

        public override void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            base.IntWall(cubeLogic, wall);
            number.text = _wall.number.x.ToString() + " " + _wall.number.y.ToString() + " " + _wall.number.z.ToString();
        }
    }
}
