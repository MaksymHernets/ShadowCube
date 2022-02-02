using ShadowCube.Models;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.Controller
{
	public class ControllerEmotions : IController
    {
		[SerializeField] private Image[] images;
		[SerializeField] private GameObject selected;

		private float angle = 0f;

		public override void Init(IModel model)
		{
			
		}

		private void Start()
		{
			angle = 360 / images.Length;
		}

		private void Update()
		{
			var norm = new Vector2(Input.mousePosition.x - Screen.width * 0.5f, Input.mousePosition.y - Screen.height * 0.5f).normalized;
			var result = Vector2.SignedAngle( norm , Vector2.up) + 180;
			int index = (int)(result / angle);
			if (index == images.Length) { index--; } 
			selected.transform.localPosition = images[index].transform.localPosition;
		}
	}
}