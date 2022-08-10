using ShadowCube.DTO;
using System;
using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class ControlSetting : MonoBehaviour, ISetting
	{
		public float speedMouse
		{
			get
			{
				return PlayerPrefs.GetFloat("SpeedMouse");
			}
			set
			{
				PlayerPrefs.SetFloat("SpeedMouse", value);
				SpeedMouse.Value = value;
			}
		}

		public ControlPC controlPC
		{
			get
			{
				return JsonUtility.FromJson<ControlPC>(PlayerPrefs.GetString("ControlPC"));
			}
			set
			{
				var jsonplayer = JsonUtility.ToJson(value);
				PlayerPrefs.SetString("ControlPC", jsonplayer);
				ReactControlPC.Value = value;
			}
		}

		public bool isShowControl
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt("IsShowControl", 1));
			}
			set
			{
				PlayerPrefs.SetInt("IsShowControl", Convert.ToInt32(value));
			}
		}

		public bool isInversionOfControl
		{
			get
			{
				return Convert.ToBoolean(PlayerPrefs.GetInt("IsInversionOfControl", 0));
			}
			set
			{
				PlayerPrefs.SetInt("IsInversionOfControl", Convert.ToInt32(value));
			}
		}

		public const float DefaultSpeedMouse = 50f;

		private void Start()
		{
			if (!PlayerPrefs.HasKey("SpeedMouse"))
			{
				PlayerPrefs.SetFloat("SpeedMouse", 0f);
			}
			if (!PlayerPrefs.HasKey("ControlPC"))
			{
				var newControlPC = new ControlPC();
				PlayerPrefs.SetString("ControlPC", JsonUtility.ToJson(newControlPC));
			}

			SpeedMouse = new ReactiveProperty<float>(speedMouse);
			ReactControlPC = new ReactiveProperty<ControlPC>(controlPC);
		}

		public void SetupDefaultSetting()
		{
			controlPC = new ControlPC();
			speedMouse = DefaultSpeedMouse;
		}

		public ReactiveProperty<float> SpeedMouse;

		public ReactiveProperty<ControlPC> ReactControlPC;
	}
}
