using UnityEngine;
using UnityEngine.UI;

public class ControllerAbout : IController
{
	[SerializeField] private Button buttonBack;

	public override void Init(IModel model)
	{

	}

	public void ButtonBack_Click()
	{
		Deactive();
		gameObject.SetActive(false);
	}
}

