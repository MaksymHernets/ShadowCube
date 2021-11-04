using UnityEngine;
using UnityEngine.UI;

public class ControllerAbout : IController
{
	[SerializeField] private Button buttonBack;

	public override void Init(IModel model)
	{
		gameObject.SetActive(true);
	}

	private void Start()
	{
		buttonBack.onClick.AddListener(ButtonBack_Click);
	}

	public void ButtonBack_Click()
	{
		Deactive();
		gameObject.SetActive(false);
	}
}

