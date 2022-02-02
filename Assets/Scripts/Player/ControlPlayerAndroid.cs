using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.Player
{
    public class ControlPlayerAndroid : MonoBehaviour
    {
        [SerializeField] private bl_Joystick stickleft;
        [SerializeField] private bl_Joystick stickright;
        [SerializeField] private Button buttonJump;
        [SerializeField] private Button buttonUse;
        [SerializeField] private Button buttonMenu;

        private IPlayerLogic _playerLogic;

        private void Start()
        {
            buttonJump.onClick.AddListener(ButtonJump_Click);
            buttonJump.onClick.AddListener(ButtonJump_Click);
            buttonJump.onClick.AddListener(ButtonJump_Click);
        }

        public void Init(IPlayerLogic playerLogic)
        {
            _playerLogic = playerLogic;
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
            //_playerLogic.OpenIte
        }

        public void ButtonItem_Click()
        {
            _playerLogic.OpenInventory();
        }

    }
}