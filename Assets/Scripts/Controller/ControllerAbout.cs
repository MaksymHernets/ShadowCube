using ShadowCube.Models;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.Controller
{
	public class ControllerAbout : IController
	{
		[SerializeField] private Button buttonBack;
		[SerializeField] private Button buttonYouTube;
		[SerializeField] private Button buttonLink;
		[SerializeField] private Animator _animator;

		public override void Init(IModel model)
		{
			gameObject.SetActive(true);
		}

		private void Start()
		{
			buttonBack.onClick.AddListener(ButtonBack_Click);
			buttonYouTube.onClick.AddListener(ButtonYouTube_Click);
			buttonLink.onClick.AddListener(ButtonLink_Click);
		}

		public void ButtonYouTube_Click()
		{
			Application.OpenURL(@"https://youtu.be/yopojM6aQ9U");
		}

		public void ButtonLink_Click()
		{
			Application.OpenURL(@"https://github.com/MaksymHernets/ShadowCube");
		}

		public void ButtonBack_Click()
		{
			_animator.SetBool("Close", true);
			Invoke("Deactive", 3f);
		}
	}
}

