using UniRx;
using UnityEngine;
using UnityEngine.Audio;

namespace ShadowCube.Setting
{
	public class GenericSetting : MonoBehaviour
	{
		[SerializeField] private AudioMixer audioMixer;

		public float globalSound
		{
			get
			{
				return PlayerPrefs.GetFloat("GlobalSound");
			}
			set
			{
				PlayerPrefs.SetFloat("GlobalSound", value);
				AudioListener.volume = value * 0.01f;
				GlobalSound.Value = value;
			}
		}

		public float globalMusic
		{
			get
			{
				return PlayerPrefs.GetFloat("GlobalMusic");
			}
			set
			{
				PlayerPrefs.SetFloat("GlobalMusic", value);
				GlobalSound.Value = value;
				audioMixer.SetFloat("Music", value-80f);
			}
		}

		public int language
		{
			get
			{
				return PlayerPrefs.GetInt("Language");
			}
			set
			{
				PlayerPrefs.SetInt("Language", value);
				Launcher.Value = value;
			}
		}

		private void Start()
		{
			if (!PlayerPrefs.HasKey("GlobalSound"))
			{
				PlayerPrefs.SetFloat("GlobalSound", 0f);
			}
			if (!PlayerPrefs.HasKey("GlobalMusic"))
			{
				PlayerPrefs.SetFloat("GlobalMusic", 0f);
			}
			if (!PlayerPrefs.HasKey("Launcher"))
			{
				PlayerPrefs.SetInt("Launcher", 0);
			}

			AudioListener.volume = PlayerPrefs.GetFloat("GlobalSound") * 0.01f;

			GlobalSound = new ReactiveProperty<float>(globalSound);
			GlobalMusic = new ReactiveProperty<float>(globalMusic);
			Launcher = new ReactiveProperty<int>(language);
		}

		public ReactiveProperty<float> GlobalSound;

		public ReactiveProperty<float> GlobalMusic;

		public ReactiveProperty<int> Launcher;
	}
}