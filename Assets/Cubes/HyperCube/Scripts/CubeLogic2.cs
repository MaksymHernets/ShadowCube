using ShadowCube.Cubes;
using UnityEngine;

namespace ShadowCubeCubes.CubeHyber
{
	public class CubeLogic2 : CubeLogic
    {
        [SerializeField] private AudioSource audioSource;

		private void OnTriggerEnter(Collider other)
		{
            audioSource.Play();
        }
	}
}
