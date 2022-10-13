using ShadowCube.DTO;
using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube.Player
{
    public class ControlPlayerPC : MonoBehaviour
    {
        [SerializeField] private PlayerLogic _playerLogic;
        [SerializeField] private ControlPC _control;

        [Inject] ControlSetting controlSetting;
        
        private void Start()
		{
            _control = controlSetting.controlPC;
        }

		public void Update()
        {
            if (ApplicationFocusSetting.IsPaused) return;

            if ( Input.GetKeyDown(_control.jump) )
            {
                _playerLogic.InputScheme.Jump?.Invoke();
            }
            if (Input.GetKey(_control.forward))
            {
                _playerLogic.InputScheme.Forward?.Invoke();
            }
            if (Input.GetKey(_control.back))
            {
                _playerLogic.InputScheme.Back?.Invoke();
            }
            if (Input.GetKey(_control.left))
            {
                _playerLogic.InputScheme.Left?.Invoke();
            }
            if (Input.GetKey(_control.right))
            {
                _playerLogic.InputScheme.Right?.Invoke();
            }

            if (Input.GetKeyDown(_control.openitem))
            {
                _playerLogic.InputScheme.OpenInventory?.Invoke();
            }
            if (Input.GetKeyDown(_control.sitdown))
            {
                _playerLogic.InputScheme.Sit?.Invoke();
            }
            if (Input.GetKeyDown(_control.use))
            {
                _playerLogic.InputScheme.Use?.Invoke();
            }

            _playerLogic.InputScheme.Rotate?.Invoke(SimpleMouse.GetPosition());
        }
    }
}