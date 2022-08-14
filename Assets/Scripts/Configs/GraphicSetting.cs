using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShadowCube.Setting
{
	public class GraphicSetting : MonoBehaviour, ISetting
	{
		public const string NAME_QualityLevel = "QualityLevel";
		public const string NAME_MaximumLODLevel = "MaximumLODLevel";

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
				QualityLevel?.Invoke(value);
			}
		}

		public int maximumLODLevel
		{
			get
			{
				return PlayerPrefs.GetInt(NAME_MaximumLODLevel, Default_MaximumLODLevel);
			}
			set
			{
				if ( value < 1 ) return;
				PlayerPrefs.SetInt(NAME_MaximumLODLevel, value);
				QualitySettings.maximumLODLevel = value;
				MaximumLODLevel?.Invoke(value);
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

		private const int Default_MaximumLODLevel = 0;
		public readonly int MaxMaximumLODLevel = 1;

		private void Start()
		{
			if (!PlayerPrefs.HasKey(NAME_QualityLevel))
			{
				PlayerPrefs.SetInt(NAME_QualityLevel, QualitySettings.GetQualityLevel());
			}
			if (!PlayerPrefs.HasKey(NAME_MaximumLODLevel))
			{
				PlayerPrefs.SetInt(NAME_MaximumLODLevel, Default_MaximumLODLevel);
			}
			if (!PlayerPrefs.HasKey("ShowFps"))
			{
				PlayerPrefs.SetInt("ShowFps", 0);
			}

			qualityLevel = PlayerPrefs.GetInt(NAME_QualityLevel);
			maximumLODLevel = PlayerPrefs.GetInt(NAME_MaximumLODLevel);
		}

		public void SetupDefaultSetting()
		{
			
		}

		public string[] GetNamesQualityLevel()
		{
			return QualitySettings.names;
		}

		public UnityAction<int> QualityLevel;

		public UnityAction<int> MaximumLODLevel;

		public UnityAction<bool> ShowFps;
	}
}
