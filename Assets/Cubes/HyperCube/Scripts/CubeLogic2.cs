using System.Collections.Generic;
using UnityEngine;

namespace Cubes.CubeHyber
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
