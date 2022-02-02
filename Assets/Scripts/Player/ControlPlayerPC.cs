using ShadowCube.DTO;
using ShadowCube.Setting;
using UnityEngine;
using Zenject;

namespace ShadowCube.Player
{
    public class ControlPlayerPC : MonoBehaviour
    {
        private ControlPC _control;
        private IPlayerLogic _playerLogic;

        [Inject] ControlSetting controlSetting;

        public void Init(IPlayerLogic playerLogic)
        {
            _playerLogic = playerLogic;

            _control = new ControlPC();
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


            //Input.mousePosition
        }


    }
}