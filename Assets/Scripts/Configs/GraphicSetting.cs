using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Setting
{
	public class GraphicSetting : MonoBehaviour, ISetting
	{
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

		private void Start()
		{
			if (!PlayerPrefs.HasKey(NAME_QualityLevel))
			{
				PlayerPrefs.SetInt(NAME_QualityLevel, QualitySettings.GetQualityLevel());
			}
			
			if (!PlayerPrefs.HasKey("ShowFps"))
			{
				PlayerPrefs.SetInt("ShowFps", 0);
			}

			qualityLevel = PlayerPrefs.GetInt(NAME_QualityLevel);
		}

		public void SetupDefaultSetting()
		{
			
		}

		public string[] GetNamesQualityLevel()
		{
			return QualitySettings.names;
		}

		public UnityAction<int> QualityLevel;

		public UnityAction<bool> ShowFps;
	}
}
