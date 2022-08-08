using ShadowCube.DTO;
using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube.Player
{
    public class ControlPlayerPC : MonoBehaviour
    {
        [SerializeField] private PlayerLogic _playerLogic;

        [Inject] ControlSetting controlSetting;

        private ControlPC _control;

        private void Start()
		{
            _control = controlSetting.controlPC;
        }

		public void Update()
        {
            if (Input.GetKeyDown(_control.openitem))
            {
                _playerLogic.OpenInventory();
            }
            if (Input.GetKeyDown(_control.jump))
            {
                _playerLogic.Jump();
            }
            if (Input.GetKeyDown(_control.use))
            {
                _playerLogic.ToUse();
            }
            if (Input.GetKeyDown(_control.sitdown))
            {
                _playerLogic.SitDown();
            }
            if (Input.GetKey(_control.forward))
            {
                _playerLogic.Forward();
            }

            float a1 = Input.GetAxis("Mouse X");
            float a2 = Input.GetAxis("Mouse Y");
            var position = new Vector3(a2, a1, 0);

            _playerLogic.RotateToPosition(position);
        }


    }
}