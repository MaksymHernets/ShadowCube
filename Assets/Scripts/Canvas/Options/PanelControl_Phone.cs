using ShadowCube.Helpers;
using ShadowCube.Player;
using ShadowCube.Setting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube
{
	public class PanelControl_Phone : OptionPanel
    {
        [SerializeField] private ControlPlayerPhone controlPlayerPhone;

		[SerializeField] private Toggle Button_ShowControl;
		[SerializeField] private Toggle Button_InversionOfControl;

		[SerializeField] private Text textMove;
		[SerializeField] private Text textView;
		[SerializeField] private Text textItem;
		[SerializeField] private Text textMenu;
		[SerializeField] private Text textUse;
		[SerializeField] private Text textJump;

		[Inject] ControlSetting controlSetting;

		private void Start()
		{
			Button_ShowControl.onValueChanged.AddListener(Button_ShowControl_Click);
			Button_InversionOfControl.onValueChanged.AddListener(Button_InversionOfControl_Click);

			Button_ShowControl.isOn = controlSetting.isShowControl;
			controlPlayerPhone.ShowControl(controlSetting.isShowControl);

			Button_InversionOfControl.isOn = controlSetting.isInversionOfControl;
		}

		public void Button_ShowControl_Click(bool key)
		{
			controlPlayerPhone.ShowControl(key);
			controlSetting.isShowControl = key;
		}

		public void Button_InversionOfControl_Click(bool key)
		{
			controlSetting.isInversionOfControl = key;

			controlPlayerPhone.InversionOfControl();
			TransformExtension.SwapTransform(textMove.gameObject, textView.gameObject);
			TransformExtension.SwapTransform(textUse.gameObject, textJump.gameObject);
			TransformExtension.SwapTransform(textItem.gameObject, textMenu.gameObject);
		}
	}
}
