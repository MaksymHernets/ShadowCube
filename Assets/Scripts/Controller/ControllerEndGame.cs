using ShadowCube.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerEndGame : IController
{
	[SerializeField] private ScoreUI scoreUI;
	[SerializeField] private Button buttonReturn;
	[SerializeField] private Button buttonOverwatch;

	protected ModelEndGame _model;

	public override void Init(IModel model)
	{
		_model = model as ModelEndGame;

		scoreUI.Show(new ShadowCube.DTO.ScoreCube() { Time = _model.Time });
		buttonReturn.onClick.AddListener(ButtonReturn_clicked);
		buttonOverwatch.onClick.AddListener(ButtonOverwatch_clicked);

		Cursor.visible = true;
	}

	private void ButtonOverwatch_clicked()
	{
		
	}

	private void ButtonReturn_clicked()
	{
		SceneManager.LoadScene(0);
	}
}
