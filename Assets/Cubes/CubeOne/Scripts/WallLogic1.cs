using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Cubes.CubeOne
{
    public class WallLogic1 : WallLogic
    {      
        public TextMesh number;

        public new void IntWall(object _object) // Wall
        {
            base.IntWall(_object);
            number.text = wall.number.x.ToString() + " " + wall.number.y.ToString() + " " + wall.number.z.ToString();
        }

        
    }
}
