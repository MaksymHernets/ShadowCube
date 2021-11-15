using ShadowCube.Models;
using ShadowCube.UI;
using UnityEngine;

namespace ShadowCube.Controller
{
    public class ControllerHUD : IController
    {
        [SerializeField] private SliderTextUI healthBar;

        private ModelHUD _model;

        public override void Init(IModel model)
        {
            _model = model as ModelHUD;

            gameObject.SetActive(true);

            _model.playerLogic.EventDamage.AddListener( eventDamage_Handler );

            Cursor.visible = false;
        }

        private void eventDamage_Handler()
        {
            healthBar.Value = _model.playerLogic.Health;
        }
    }
}