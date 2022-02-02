using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ShadowCube.UI
{
	public class BoxHolderUI : MonoBehaviour
	{
		public UnityAction<int> Event_Click;
		public int index = 0;

		[SerializeField] private Button button;

		private void Start()
		{
			button.onClick.AddListener(Button_Click);
		}

		private void Button_Click()
		{
			Event_Click.Invoke(index);
		}
	}
}

