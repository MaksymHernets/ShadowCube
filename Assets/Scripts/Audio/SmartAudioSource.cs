using System.Collections;
using UnityEngine;

namespace ShadowCube
{
	public class SmartAudioSource : MonoBehaviour
    {
        [SerializeField] public AudioSource audioSource;

		private Coroutine coroutineStoping;

		private static readonly float MaxValue = 1f;

		public void Stop(float time)
		{
			if ( coroutineStoping == null )
			{
				coroutineStoping = StartCoroutine(StopingAudioClip(time));
			}
		}

		private IEnumerator StopingAudioClip(float time)
		{
			float deltaTime = time;
			while (deltaTime > 0 )
			{
				audioSource.volume = deltaTime / time ;
				deltaTime -= Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			audioSource.Stop();
			audioSource.volume = MaxValue;
			coroutineStoping = null;
		}
	}
}
