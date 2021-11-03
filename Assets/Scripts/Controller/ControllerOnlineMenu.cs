using UnityEngine;
using UnityEngine.UI;

public class ControllerOnlineMenu : IController
{
	[SerializeField] private Button buttonBack;
	[Header("BarUP")]
	[SerializeField] private Button buttonIsLocal;
	[SerializeField] private Button buttonRefresh;
	[SerializeField] private Button buttonCubeOne;
	[SerializeField] private Button buttonHyperCube;
	[SerializeField] private Button buttonCubeZero;
	[SerializeField] private Button buttonSketchCube;
	[Header("Table")]
	[SerializeField] private ItemHost prefabItem;
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
		Deactive();
		gameObject.SetActive(false);
	}
}
