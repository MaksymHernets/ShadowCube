using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControllerPersonMenu : IController
{
	[SerializeField] private Button buttonBack;

	[Header("Property")]
	[SerializeField] private InputField inputFieldName;
	[SerializeField] private Dropdown dropdownGender;

	[Header("Other")]
	[SerializeField] private CPC_CameraPath cameraPath;
    [SerializeField] private GameObject person;

    private ModelPersonMenu _model;

	[Inject] GameSetting gameSetting;

    public override void Init(IModel model)
    {
        _model = model as ModelPersonMenu;

		gameObject.SetActive(true);

		cameraPath.points.Reverse();
		cameraPath.PlayPath(2);
		person.SetActive(true);

		inputFieldName.text = _model.playerDTO.Name;
		dropdownGender.value = _model.playerDTO.Gender;
	}

	private void Start()
	{
		buttonBack.onClick.AddListener(ButtonBack_Click);

		inputFieldName.onValueChanged.AddListener(inputFieldName_click);
		dropdownGender.onValueChanged.AddListener(dropdownGender_click);
	}

	private void inputFieldName_click(string newtext)
	{
		_model.playerDTO.Name = newtext;
	}

	private void dropdownGender_click(int newindex)
	{
		_model.playerDTO.Gender = newindex;
	}

	public void ButtonBack_Click()
	{
		gameSetting.UpdatePlayerDTO(_model.playerDTO);
		Deactive();
	}

	public override void Deactive()
	{
		StartCoroutine(DeactiveScript());
	}

	private IEnumerator DeactiveScript()
	{
		cameraPath.points.Reverse();
		cameraPath.PlayPath(2);
		person.SetActive(false);
		yield return new WaitForSeconds(2.5f);
		base.Deactive();
	}
}
