using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class ControlSetting : MonoBehaviour
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
				_speedMouse.Value = value;
			}
		}

		private void Start()
		{
			if (!PlayerPrefs.HasKey("SpeedMouse"))
			{
				PlayerPrefs.SetFloat("SpeedMouse", 0f);
			}

			_speedMouse = new ReactiveProperty<float>(speedMouse);
		}

		private ReactiveProperty<float> _speedMouse;
	}
}
