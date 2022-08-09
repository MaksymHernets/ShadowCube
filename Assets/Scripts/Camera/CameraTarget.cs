using UnityEngine;

namespace ShadowCube
{
    public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        void Update()
        {
            this.transform.position = target.transform.position;
        }
    }
}
