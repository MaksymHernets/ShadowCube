using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShadowCube.Cubes
{
    public abstract class WallLogic : MonoBehaviour
    {
        [SerializeField] private DoorLogic door;
        [SerializeField] private Light _light;
        [SerializeField] private LODGroup _LODGroup;

        protected CubeLogic _cubeLogic;
        protected WallDTO _wall;

        public virtual void IntWall(CubeLogic cubeLogic, WallDTO wall)
        {
            _cubeLogic = cubeLogic;
            _wall = wall;
        }

        public void SetColorPanel(Color color)
        {
			foreach (LOD Lod in _LODGroup.GetLODs().ToList())
			{
                Lod.renderers[0].sharedMaterials[1].SetColor("_EmissionColor", _wall.color);
                Lod.renderers[0].sharedMaterials[2].SetColor("_EmissionColor", _wall.color);
            }
        }

        public void SetMaterialForWall(params Material[] materials)
        {
            foreach (LOD Lod in _LODGroup.GetLODs().ToList())
            {
                Lod.renderers[0].sharedMaterials[1] = materials[0];
                Lod.renderers[0].sharedMaterials[2] = materials[1];
            }
            //foreach (var material in materials)
            //{
            //    int index = meshRenderer.sharedMaterials.ToList().IndexOf(material);
            //    meshRenderer.sharedMaterials[index] = material;
            //}
        }

        public virtual void ToOpenDoor()
        {
            if ( _light != null)
            _light.gameObject.SetActive(true);
            door.Open();
        }

        public virtual void ToCloseDoor()
        {
            door.Close();
        }

        public void OpenedDoor()
        {
            _cubeLogic.EventOpenedDoor(_wall.id);
        }

        public void ClosedDoor()
        {
            if (_light != null)
                _light.gameObject.SetActive(false);
            _cubeLogic.EventClosedDoor(_wall.id);
        }
    }

    public class WallDTO
    {
        public int id { set; get; }
        public Vector3Int number { set; get; }
        public Color color { set; get; }
    }
}
