using UnityEngine;
using UnityEngine.UI;

public class ControllerOnlineMenu : IController
{
	[SerializeField] private Button buttonBack;
	[SerializeField] private Animator _animator;

	[Header("BarUP")]
	[SerializeField] private Button buttonIsLocal;
	[SerializeField] private Button buttonRefresh;
	[SerializeField] private Button buttonCubeOne;
	[SerializeField] private Button buttonHyperCube;
	[SerializeField] private Button buttonCubeZero;
	[SerializeField] private Button buttonSketchCube;

	[Header("Table")]
	[SerializeField] private Transform contect;

	protected ModelOnlineMenu _model;

    public override void Init(IModel model)
    {
        _model = model as ModelOnlineMenu;

		gameObject.SetActive(true);

		buttonRefresh.onClick.AddListener(ButtonRefresh_Click);
		buttonIsLocal.onClick.AddListener(ButtonIsLocal_Click);

		buttonBack.onClick.AddListener(ButtonBack_Click);
	}

	public void ButtonIsLocal_Click()
	{

	}

	public void ButtonRefresh_Click()
	{

	}

	public void InputFieldIp_EndEdit(string ip)
	{

	}

	public void ButtonBack_Click()
	{
		_animator.SetBool("Close", true);
		Invoke("Deactive", 3f);
	}
}
