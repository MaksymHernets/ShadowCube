using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.UI
{
	public class SliderTextUI : MonoBehaviour
	{
		[SerializeField] public Slider slider;
		[SerializeField] private Text text;
		[SerializeField] private string formatString = "G";

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
				if ( slider.minValue > value ) text.text = slider.minValue.ToString(formatString);
				else if ( slider.maxValue < value ) text.text = slider.maxValue.ToString(formatString);
				else text.text = value.ToString(formatString);
			}
		}

		private void Start()
		{
			slider.onValueChanged.AddListener(OnValueChanged);
		}

		private void OnValueChanged(float value)
		{
			text.text = value.ToString(formatString);
		}
	}
}
