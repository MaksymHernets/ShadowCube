using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Setting
{
	public class GraphicSetting : MonoBehaviour, ISetting
	{
		public const string NAME_ScreenEffect = "ScreenEffect";
		public const string NAME_QualityLevel = "QualityLevel";

		public int qualityLevel
		{
			get
			{
				return PlayerPrefs.GetInt(NAME_QualityLevel, QualitySettings.GetQualityLevel());
			}
			set
			{
				PlayerPrefs.SetInt(NAME_QualityLevel, value);
				QualitySettings.SetQualityLevel(value, true);
			}
		}

		public int screenEffect
		{
			get
			{
				return PlayerPrefs.GetInt(NAME_ScreenEffect);
			}
			set
			{
				PlayerPrefs.SetInt(NAME_ScreenEffect, value);
				ScreenEffect?.Invoke(value);
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
				QualitySettings.maxQueuedFrames = value;
				MaxFPS?.Invoke(value);
			}
		}

		public int fieldOfView
		{
			get
			{
				return PlayerPrefs.GetInt("ViewCamera", DefaultViewCamera);
			}
			set
			{
				PlayerPrefs.SetInt("ViewCamera", value);
				FieldOfView?.Invoke(value);
			}
		}

		public int syncCount
		{
			get
			{
				return PlayerPrefs.GetInt("SyncCount");
			}
			set
			{
				PlayerPrefs.SetInt("SyncCount", value);
				QualitySettings.vSyncCount = value;
			}
		}

		public bool showFps
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt("ShowFps"));
			}
			set
			{
				PlayerPrefs.SetInt("ShowFps", Convert.ToInt32(value));
				ShowFps?.Invoke(value);
			}
		}

		public readonly int MinFPS = 30;
#if UNITY_ANDROID || UNITY_IPHONE
		public readonly int MaxMaxFPS = 144;
#else
		public readonly int MaxMaxFPS = 300;
#endif
		public readonly int MinViewCamera = 70;
		public readonly int MaxViewCamera = 90;

		public const int DefaultMaxFPS = 60;
		public const int DefaultViewCamera = 75;

		private void Start()
		{
			if (!PlayerPrefs.HasKey(NAME_QualityLevel))
			{
				PlayerPrefs.SetInt(NAME_QualityLevel, QualitySettings.GetQualityLevel());
			}
			if (!PlayerPrefs.HasKey(NAME_ScreenEffect))
			{
				PlayerPrefs.SetInt(NAME_ScreenEffect, 0);
			}
			if (!PlayerPrefs.HasKey("MaxFPS"))
			{
				PlayerPrefs.SetInt("MaxFPS", DefaultMaxFPS);
			}
			if (!PlayerPrefs.HasKey("ViewCamera"))
			{
				PlayerPrefs.SetInt("ViewCamera", DefaultViewCamera);
			}
			if (!PlayerPrefs.HasKey("SyncCount"))
			{
				PlayerPrefs.SetInt("SyncCount", 0);
			}
			if (!PlayerPrefs.HasKey("ShowFps"))
			{
				PlayerPrefs.SetInt("ShowFps", 0);
			}

			maxFPS = PlayerPrefs.GetInt("MaxFPS");
			qualityLevel = PlayerPrefs.GetInt(NAME_QualityLevel);
		}

		public void SetupDefaultSetting()
		{
			maxFPS = DefaultMaxFPS;
			fieldOfView = DefaultViewCamera;
		}

		public string[] GetNamesQualityLevel()
		{
			return QualitySettings.names;
		}

		public List<string> GetNamesSync()
		{
			List<string> names = new List<string>();
			names.Add("Dont Sync");
#if !PLATFORM_ANDROID
			names.Add("Every V blank"); // ignored Android, IOS, Apple TV
			names.Add("Every second V blank"); // ignored Android, IOS, Apple TV
#endif
			return names;
		}

		public List<string> GetNamesEffect()
		{
			List<string> names = new List<string>();
			names.Add("No");
			names.Add("Blur");
			return names;
		}

		public UnityAction<int> QualityLevel;

		public UnityAction<int> FieldOfView;

		public UnityAction<int> MaxFPS;

		public UnityAction<int> ScreenEffect;

		public UnityAction<int> Quality;

		public UnityAction<int> SyncCount;

		public UnityAction<bool> ShowFps;
	}
}
