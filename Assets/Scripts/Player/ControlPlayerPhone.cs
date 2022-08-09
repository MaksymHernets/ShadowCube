using ShadowCube.Helpers;
using ShadowCube.Setting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ShadowCube.Player
{
    public class ControlPlayerPhone : MonoBehaviour
    {
        public bool IsShow { get; private set; }

        [SerializeField] private bl_Joystick stickleft;
        [SerializeField] private bl_Joystick stickright;
        [SerializeField] private Button buttonJump;
        [SerializeField] private Button buttonUse;
        [SerializeField] private Button buttonMenu;
        [SerializeField] private Button buttonItem;

        [SerializeField] private PlayerLogic _playerLogic;

        private void Start()
        {
            buttonJump.onClick.AddListener(ButtonJump_Click);
            buttonUse.onClick.AddListener(ButtonUse_Click);
            buttonMenu.onClick.AddListener(ButtonMenu_Click);
            buttonItem.onClick.AddListener(ButtonItem_Click);
        }

        public void ShowControl(bool key)
		{
            IsShow = key;
            stickleft.GetComponent<Image>().gameObject.SetActive(IsShow);
            stickright.GetComponent<Image>().gameObject.SetActive(IsShow);
            buttonJump.GetComponent<Image>().gameObject.SetActive(IsShow);
            buttonUse.GetComponent<Image>().gameObject.SetActive(IsShow);
            buttonMenu.GetComponent<Image>().gameObject.SetActive(IsShow);
            buttonItem.GetComponent<Image>().gameObject.SetActive(IsShow);
        }

        public void InversionOfControl()
		{
            TransformExtension.SwapTransform(stickleft.gameObject, stickright.gameObject);
            TransformExtension.SwapTransform(buttonJump.gameObject, buttonUse.gameObject);
            TransformExtension.SwapTransform(buttonMenu.gameObject, buttonItem.gameObject);
        }

        public void ButtonJump_Click()
        {
            _playerLogic.Jump();
        }

        public void ButtonUse_Click()
        {
            _playerLogic.ToUse();
        }

        public void ButtonMenu_Click()
        {
            //_playerLogic.OpenMenu();
        }

        public void ButtonItem_Click()
        {
            _playerLogic.OpenInventory();
        }
    }
}