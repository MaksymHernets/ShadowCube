using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
    public class BaseAudioManager : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private List<AudioSource> audioSources;

        protected Dictionary<string, AudioSource> collection = new Dictionary<string, AudioSource>();

        private AudioSource audioSource;

		private void Start()
		{
            if (audioClips != null && audioClips.Count !=0 )
			{
                SetupAudio(audioClips);
            }
			foreach (var source in audioSources)
			{
                collection.Add(source.clip.name, source);
            }
        }

		public virtual void SetupAudio(List<AudioClip> lists)
        {
            AudioSource tempAudioSource = default(AudioSource);

            foreach (var audioClip in lists)
            {
                tempAudioSource = this.gameObject.AddComponent<AudioSource>();
                tempAudioSource.clip = audioClip;

                collection.Add(audioClip.name, tempAudioSource);
            }
        }

        public void PlayAudioClip_String(string name)
        {
            collection[name].Play();
        }

        public void PlayAudioClip_String(string name, float timelenght)
        {
            AudioSource audioSource = collection[name];
            float timeScale = audioSource.clip.length / timelenght;
            audioSource.PlayOneShot(audioSource.clip, timeScale);
        }

        public void PlayAudioClip(AudioClip audioClip)
        {
            if (audioSource != null) Destroy(audioSource);
            audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
