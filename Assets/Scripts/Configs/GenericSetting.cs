using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Localization.Settings;

namespace ShadowCube.Setting
{
	public class GenericSetting : MonoBehaviour, ISetting
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
				GlobalSound.Invoke(value);
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
				GlobalMusic.Invoke(value);
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
				LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
				Launcher.Invoke(value);
			}
		}

		public int region
		{
			get
			{
				return PlayerPrefs.GetInt("Region");
			}
			set
			{
				PlayerPrefs.SetInt("Region", value);
				Region.Invoke(value);
			}
		}

		public const float DefaultGlobalSound = 50f;
		public const float DefaultGlobalMusic = 50f;

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
			if (!PlayerPrefs.HasKey("Region"))
			{
				PlayerPrefs.SetInt("Region", 0);
			}

			AudioListener.volume = PlayerPrefs.GetFloat("GlobalSound") * 0.01f;
		}

		public List<string> GetLanguages()
        {
			return LocalizationSettings.AvailableLocales.Locales.Select(w => w.LocaleName).ToList();
		}

		public void SetupDefaultSetting()
		{
			globalSound = DefaultGlobalSound;
			globalMusic = DefaultGlobalMusic;
		}

		public List<string> GetRegions()
		{
			List<string> names = new List<string>();
			names.Add("Europe");
			names.Add("Asia");
			names.Add("America");
			names.Add("CIS");
			return names;
		}

		public UnityAction<float> GlobalSound;

		public UnityAction<float> GlobalMusic;

		public UnityAction<int> Launcher;

		public UnityAction<int> Region;
	}
}