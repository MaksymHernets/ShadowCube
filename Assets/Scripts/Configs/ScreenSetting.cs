using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Setting
{
	public class ScreenSetting : MonoBehaviour, ISetting
    {
		public const string Name_AutoRotate = "AutoRotate";
		public const string Name_ScaleRender = "ScaleRender";

		public const string NAME_PostEffect = "PostEffect";
		public const string NAME_PostEffectBloom = "PostEffectBloom";
		public const string NAME_PostEffectFocus = "PostEffectFocus";

		public Vector2Int displayResolution
		{
			get
			{
				int x = PlayerPrefs.GetInt("WidthScreen");
				int y = PlayerPrefs.GetInt("HeightScreen");
				return new Vector2Int(x,y);
			}
			set
			{
				PlayerPrefs.SetInt("WidthScreen", value.x);
				PlayerPrefs.SetInt("HeightScreen", value.y);
				Screen.SetResolution(value.x, value.y, screenMode);
				DisplayResolution.Value = value;
			}
		}

		public FullScreenMode screenMode
		{
			get
			{
				int index = PlayerPrefs.GetInt("ScreenMode");
				return Screen.fullScreenMode;
			}
			set
			{
				PlayerPrefs.SetInt("ScreenMode", (int)value);
				Screen.SetResolution(Screen.width, Screen.height, value);
			}
		}

		public float scaleRender
		{
			get
			{
				return PlayerPrefs.GetFloat(Name_ScaleRender, DefaultScaleRender);
			}
			set
			{
				if (MaxScaleRender < value) return;
				if (MinScaleRender > value) return;
				PlayerPrefs.SetFloat(Name_ScaleRender, value);
				int x = (int)(Display.main.systemWidth * value);
				int y = (int)(Display.main.systemHeight * value);
				Display.main.SetRenderingResolution(x, y);
				ScaleRender?.Invoke(value);
			}
		}

		public bool autoRotate
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt(Name_AutoRotate));
			}
			set
			{
				PlayerPrefs.SetInt(Name_AutoRotate, Convert.ToInt32(value));
				Screen.autorotateToLandscapeLeft = value;
				Screen.autorotateToLandscapeRight = value;
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
				Application.targetFrameRate = value;
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

		public bool postEffect
		{
			get
			{
				return Convert.ToBoolean( PlayerPrefs.GetInt(NAME_PostEffect));
			}
			set
			{
				PlayerPrefs.SetInt(NAME_PostEffect, Convert.ToInt32(value));
				PostEffect?.Invoke(value);
			}
		}

		public bool postEffect_Bloom
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt(NAME_PostEffectFocus));
			}
			set
			{
				PlayerPrefs.SetInt(NAME_PostEffectFocus, Convert.ToInt32(value));
				PostEffect_Bloom?.Invoke(value);
			}
		}

		public bool postEffect_Focus
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt(NAME_PostEffect));
			}
			set
			{
				PlayerPrefs.SetInt(NAME_PostEffect, Convert.ToInt32(value));
				PostEffect_Focus?.Invoke(value);
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

		public readonly float DefaultScaleRender = 1f;
#if UNITY_ANDROID || UNITY_IPHONE
		public readonly float MinScaleRender = 0.4f;
#else
		public readonly float MinScaleRender = 0.5f;
#endif
		public readonly float MaxScaleRender = 1f;

		public readonly int MinFPS;
		public readonly int MaxMaxFPS;
		public readonly int MinViewCamera;
		public readonly int MaxViewCamera;

		public const int DefaultMaxFPS = 60;
		public const int DefaultViewCamera = 75;

		public ScreenSetting()
		{
			MinFPS = 30;
#if UNITY_ANDROID || UNITY_IPHONE
			MaxMaxFPS = 144;
#else
			MaxMaxFPS = 300;
#endif
			MinViewCamera = 70;
			MaxViewCamera = 90;
		}

		private void Start()
		{
			if (!PlayerPrefs.HasKey(Name_ScaleRender))
			{
				float scaleRender = DefaultScaleRender;
#if UNITY_ANDROID || UNITY_IPHONE
				if ( Display.main.systemWidth > 3000 ) scaleRender = 0.4f;
				else if ( Display.main.systemWidth > 2500 ) scaleRender = 0.6f;
				else if ( Display.main.systemWidth > 1900 ) scaleRender = 0.8f;
#endif
				PlayerPrefs.SetFloat(Name_ScaleRender, scaleRender);
			}
			if (!PlayerPrefs.HasKey("ScreenMode"))
			{
				PlayerPrefs.SetInt("ScreenMode", 1);
			}
			if (!PlayerPrefs.HasKey("WidthScreen"))
			{
				PlayerPrefs.SetInt("WidthScreen", Screen.width);
			}
			if (!PlayerPrefs.HasKey("HeightScreen"))
			{
				PlayerPrefs.SetInt("HeightScreen", Screen.height);
			}
			if (!PlayerPrefs.HasKey(Name_AutoRotate))
			{
				PlayerPrefs.SetInt(Name_AutoRotate, 0);
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
			if (!PlayerPrefs.HasKey(NAME_PostEffect))
			{
				PlayerPrefs.SetInt(NAME_PostEffect, 0);
			}

			DisplayResolution = new ReactiveProperty<Vector2Int>(displayResolution);
			scaleRender = PlayerPrefs.GetFloat(Name_ScaleRender);
			autoRotate = Convert.ToBoolean(PlayerPrefs.GetInt(Name_AutoRotate));
			maxFPS = PlayerPrefs.GetInt("MaxFPS");
		}

		public void SetupDefaultSetting()
		{
			maxFPS = DefaultMaxFPS;
			fieldOfView = DefaultViewCamera;
		}

		public string[] GetNameScreenMode()
		{
			return Enum.GetNames(typeof(FullScreenMode));
		}

		public List<string> GetNameDisplays()
		{
			List<string> names = new List<string>();
			foreach (Display display in Display.displays)
			{
				names.Add("unknown");
			}
			names[0] = Screen.mainWindowDisplayInfo.name;
			return names;
		}

		public string GetSystemResolution()
		{
			return Display.main.systemWidth + " x " + Display.main.systemHeight;
		}

		public string GetRenderingResolution()
		{
			return Display.main.renderingWidth + " x " + Display.main.renderingHeight;
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

		public ReactiveProperty<Vector2Int> DisplayResolution;

		public UnityAction<float> ScaleRender;

		public UnityAction<int> FieldOfView;

		public UnityAction<int> MaxFPS;

		public UnityAction<int> SyncCount;

		public UnityAction<bool> PostEffect;

		public UnityAction<bool> PostEffect_Bloom;

		public UnityAction<bool> PostEffect_Focus;
	}
}
