using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
    public class DoorSoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource_OpeningHandle;
        [SerializeField] private AudioSource audioSource_OpeningDoor;

        public void SoundDoor()
        {
            audioSource_OpeningDoor.Play();
        }

        public void SoundHandle()
        {
            audioSource_OpeningHandle.Play();
        }
    }
}
