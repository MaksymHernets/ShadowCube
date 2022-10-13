using ShadowCube.Models;
using ShadowCube.Setting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube.Controller
{
	public class ControllerPersonMenu : IController
	{
		[SerializeField] private Button buttonBack;
		[SerializeField] private Animator _animator;

		[Header("Property")]
		[SerializeField] private InputField inputFieldName;
		[SerializeField] private Dropdown dropdownGender;

		private ModelPersonMenu _model;

		[Inject] GameSetting gameSetting;

		private float _timeDeactivate = 2f;

		public override void Init(IModel model)
		{
			_model = model as ModelPersonMenu;

			gameObject.SetActive(true);

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
			_animator.SetBool("Close", true);
			Invoke("Deactive", _timeDeactivate);
		}
	}
}