using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class ScreenSetting : MonoBehaviour, ISetting
    {
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
				return PlayerPrefs.GetFloat("ScaleRender");
			}
			set
			{
				PlayerPrefs.SetFloat("ScaleRender", value);
				int x = (int)(displayResolution.x * value * 0.01f);
				int y = (int)(displayResolution.y * value * 0.01f);
				//Screen.SetResolution(x, y, Screen.mainWindowDisplayInfo)
				//Screen.SetResolution(Screen.width, Screen.height, value);
			}
		}

		public readonly float MinScaleRender = 0.7f;
		public readonly float MaxScaleRender = 1f;

		private void Start()
		{
			if (!PlayerPrefs.HasKey("ScaleRender"))
			{
				PlayerPrefs.SetFloat("ScaleRender", 1f);
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

			DisplayResolution = new ReactiveProperty<Vector2Int>(displayResolution);
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
