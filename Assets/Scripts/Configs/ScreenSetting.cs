using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class ScreenSetting : MonoBehaviour, ISetting
    {
		public const string Name_AutoRotate = "AutoRotate";
		public const string Name_ScaleRender = "ScaleRender";

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
				return PlayerPrefs.GetFloat(Name_ScaleRender);
			}
			set
			{
				if (MaxScaleRender < value) return;
				if (MinScaleRender > value) return;
				PlayerPrefs.SetFloat(Name_ScaleRender, value);
				int x = (int)(displayResolution.x * value);
				int y = (int)(displayResolution.y * value);
				Display.main.SetRenderingResolution(x, y);
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

		public readonly float MinScaleRender = 0.5f;
		public readonly float MaxScaleRender = 1f;

		private void Start()
		{
			if (!PlayerPrefs.HasKey(Name_ScaleRender))
			{
				PlayerPrefs.SetFloat(Name_ScaleRender, 1f);
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

			DisplayResolution = new ReactiveProperty<Vector2Int>(displayResolution);
			scaleRender = PlayerPrefs.GetFloat(Name_ScaleRender);
			autoRotate = Convert.ToBoolean(PlayerPrefs.GetInt(Name_AutoRotate));
		}

		public void SetupDefaultSetting()
		{
			
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

		public ReactiveProperty<Vector2Int> DisplayResolution;

		public ReactiveProperty<int> ScaleRender;
	}
}
