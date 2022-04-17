using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeOne
{
	public class CubeLogic1 : CubeLogic
    {
        public override void SetColorRoom(Color color)
        {
            MeshRenderer meshRenderer = _walls[0].GetComponent<MeshRenderer>();
            Material copyMaterial1 = meshRenderer.sharedMaterials[1];
            Material copyMaterial2 = meshRenderer.sharedMaterials[2];
            copyMaterial1.SetColor("_EmissionColor", color);
            copyMaterial2.SetColor("_EmissionColor", color);

            foreach (var wall in _walls)
            {
                wall.SetMaterialForWall(copyMaterial1, copyMaterial2);
            }
        }
    }
}
