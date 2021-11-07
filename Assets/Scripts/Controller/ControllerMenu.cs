using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControllerMenu : IController
{
	[HideInInspector] public UnityEvent EventOpenedMenu;
	[HideInInspector] public UnityEvent EventClosedMenu;

	[SerializeField] private KeyCode KeyCodeCallMenu = KeyCode.Escape;
	[SerializeField] private GameObject Fon;
	[SerializeField] private GameObject BlockLeft;
	[SerializeField] private GameObject BlockRight;

	[Header("Block")]
	[SerializeField] private Button buttonResume;
	[SerializeField] private Button buttonStatus;
	[SerializeField] private Button buttonOption;
	[SerializeField] private Button buttonLeave;

	[Header("Prefabs")]
	[SerializeField] private ControllerOptionMenu prefabCanvasMenuOption;

	private bool IsActive = false;
	private ControllerOptionMenu _gameobjectMenuOption;

	public override void Init(IModel model)
	{
		gameObject.SetActive(true);
	}

	private void Start()
	{
		buttonResume.onClick.AddListener(ButtonResume_Click);
		buttonStatus.onClick.AddListener(ButtonStatus_Click);
		buttonOption.onClick.AddListener(ButtonOption_Click);
		buttonLeave.onClick.AddListener(ButtonLeave_Click);

	}

	void Update()
    {
        if ( Input.GetKeyDown(KeyCodeCallMenu) )
		{
			IsActive = !IsActive;
			Fon.SetActive(IsActive);
			Cursor.visible = IsActive;
			if ( IsActive )
			{
				EventOpenedMenu.Invoke();
			}
			else
			{
				EventClosedMenu.Invoke();
			}
		}
    }

	private void Handler_MenuOption_Close()
	{
		_gameobjectMenuOption.EventClose.RemoveListener(Handler_MenuOption_Close);
		GameObject.Destroy(_gameobjectMenuOption.gameObject);
		buttonOption.onClick.AddListener(ButtonOption_Click);
	}

	private void ButtonResume_Click()
	{
		IsActive = false;
		Fon.SetActive(false);
		Cursor.visible = false;
		EventClosedMenu.Invoke();
	}

	private void ButtonStatus_Click()
	{

	}

	private void ButtonOption_Click()
	{
		buttonOption.onClick.RemoveListener(ButtonOption_Click);
		_gameobjectMenuOption = GameObject.Instantiate(prefabCanvasMenuOption, BlockRight.transform);
		_gameobjectMenuOption.Init(new ModelOptionMenu());
		_gameobjectMenuOption.EventClose.AddListener(Handler_MenuOption_Close);
	}

	private void ButtonLeave_Click()
	{
		SceneManager.LoadScene(0);
	}
}
