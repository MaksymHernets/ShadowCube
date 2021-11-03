using UnityEngine;

public class ControllerHUD : IController
{
    public GameObject Menu;
    public FrameDamageUI frameDamageUI;
    public Items itemsui;

    private ModelHUD _model;

    public override void Init(IModel model)
	{
        _model = model as ModelHUD;

        _model.playerLogic.EventDamage.AddListener( eventDamage_Handler );

        Cursor.visible = false;
    }

    private void eventDamage_Handler()
	{
        frameDamageUI.Show(_model.playerLogic.Health);
    }
}
