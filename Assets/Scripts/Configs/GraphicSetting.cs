using UniRx;
using UnityEngine;

namespace ShadowCube.Setting
{
	public class GraphicSetting : MonoBehaviour
	{
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

		private void Start()
		{
			if (!PlayerPrefs.HasKey("WidthScreen"))
			{
				PlayerPrefs.SetFloat("WidthScreen", 0f);
			}
			if (!PlayerPrefs.HasKey("ScreenEffect"))
			{
				PlayerPrefs.SetInt("ScreenEffect", 0);
			}
			if (!PlayerPrefs.HasKey("MaxFPS"))
			{
				PlayerPrefs.SetInt("MaxFPS", 0);
			}

			//_widthScreen = new ReactiveProperty<float>(globalSound);
			ScreenEffect = new ReactiveProperty<int>(screenEffect);
			MaxFPS = new ReactiveProperty<int>(maxFPS);
		}

		public ReactiveProperty<int> HeightScreen;

		public ReactiveProperty<int> WidthScreen;
		
		public IReadOnlyReactiveProperty<int> MaxFPS;

		public ReactiveProperty<int> ScreenEffect;

		public ReactiveProperty<int> Quality;
	}
}
