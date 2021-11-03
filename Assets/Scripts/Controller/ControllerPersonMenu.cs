using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerPersonMenu : IController
{
	[SerializeField] private Button buttonBack; 
    [SerializeField] private CPC_CameraPath cameraPath;
    [SerializeField] private GameObject person;

    private ModelPersonMenu _model;

    public override void Init(IModel model)
    {
        _model = model as ModelPersonMenu;

		gameObject.SetActive(true);

		cameraPath.points.Reverse();
		cameraPath.PlayPath(2);
		person.SetActive(true);
	}

	private void Start()
	{
		buttonBack.onClick.AddListener(ButtonBack_Click);
	}

	public void ButtonBack_Click()
	{
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
