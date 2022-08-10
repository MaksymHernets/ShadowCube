using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube
{
	public class MusicFonManager : MonoBehaviour
    {
        [SerializeField] private List<SmartAudioSource> AudioSources;
		[SerializeField] private float DelayPlay = 10f;
		[SerializeField] private float TimeDecreaseVolume = 2f;

		private int _oldIndex = 0;

		public void Clear(int indexSave)
		{
			int index = 0;
			foreach (SmartAudioSource audioSource in AudioSources)
			{
				if ( index != indexSave) GameObject.Destroy(audioSource.gameObject);
				++index;
			}
		}

		public void Play(int newIndex)
		{
			if ( _oldIndex != newIndex )
			{
				AudioSources[_oldIndex].Stop(TimeDecreaseVolume);
			}
			if ( !AudioSources[newIndex].audioSource.isPlaying )
			{
				AudioSources[newIndex].audioSource.PlayDelayed(DelayPlay);
			}
			_oldIndex = newIndex;
		}
	}
}
