using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class GraphicSetting : MonoBehaviour, ISetting
	{
		public int qualityLevel
		{
			get
			{
				return QualitySettings.GetQualityLevel();
			}
			set
			{
				QualitySettings.SetQualityLevel(value, true);
			}
		}

		public int screenEffect
		{
			get
			{
				return PlayerPrefs.GetInt("ScreenEffect");
			}
			set
			{
				PlayerPrefs.SetInt("ScreenEffect", value);
				ScreenEffect.Value = value;
			}
		}

		public int maxFPS
		{
			get
			{
				return PlayerPrefs.GetInt("MaxFPS");
			}
			set
			{
				PlayerPrefs.SetInt("MaxFPS", value);
				MaxFPS = new ReactiveProperty<int>(value);
				QualitySettings.maxQueuedFrames = value;
			}
		}

		public int viewCamera
		{
			get
			{
				return PlayerPrefs.GetInt("ViewCamera");
			}
			set
			{
				PlayerPrefs.SetInt("ViewCamera", value);
				QualitySettings.vSyncCount = value;
				ViewCamera = new ReactiveProperty<int>(value);
			}
		}

		public const int DefaultMaxFPS = 60;
		public const int DefaultViewCamera = 75;

		private void Start()
		{
			if (!PlayerPrefs.HasKey("ScreenEffect"))
			{
				PlayerPrefs.SetInt("ScreenEffect", 0);
			}
			if (!PlayerPrefs.HasKey("MaxFPS"))
			{
				PlayerPrefs.SetInt("MaxFPS", 0);
			}
			if (!PlayerPrefs.HasKey("ViewCamera"))
			{
				PlayerPrefs.SetInt("ViewCamera", 0);
			}

			ScreenEffect = new ReactiveProperty<int>(screenEffect);
			MaxFPS = new ReactiveProperty<int>(maxFPS);
			ViewCamera = new ReactiveProperty<int>(viewCamera);
		}

		public void SetupDefaultSetting()
		{
			maxFPS = DefaultMaxFPS;
			viewCamera = DefaultViewCamera;
		}

		public string[] GetNamesQualityLevel()
		{
			return QualitySettings.names;
		}

		public List<string> GetNamesSync()
		{
			List<string> names = new List<string>();
			names.Add("Dont Sync");
			names.Add("Every V blank"); // ignored Android, IOS, Apple TV
			names.Add("Every every V blank"); // ignored Android, IOS, Apple TV
			return names;
		}

		public List<string> GetNamesEffect()
		{
			List<string> names = new List<string>();
			names.Add("No");
			names.Add("Blur");
			names.Add("Real");
			return names;
		}

		public ReactiveProperty<int> QualityLevel;

		public ReactiveProperty<int> ViewCamera;

		public ReactiveProperty<int> MaxFPS;

		public ReactiveProperty<int> ScreenEffect;

		public ReactiveProperty<int> Quality;
	}
}
