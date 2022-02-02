using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.UI
{
	public class SliderTextUI : MonoBehaviour
	{
		[SerializeField] public Slider slider;
		[SerializeField] private Text text;

		[HideInInspector]
		public float Value
		{
			get
			{
				return slider.value;
			}
			set
			{
				slider.value = value;
				text.text = value.ToString("G");
			}
		}

		private void Start()
		{
			slider.onValueChanged.AddListener(OnValueChanged);
		}

		private void OnValueChanged(float value)
		{
			text.text = value.ToString("G");
		}
	}
}
