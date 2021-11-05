using UnityEngine;
using UnityEngine.UI;

public class ControllerAbout : IController
{
	[SerializeField] private Button buttonBack;
	[SerializeField] private Animator _animator;

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
		_animator.SetBool("Close", true);
		Invoke("Deactive", 3f);
	}
}

