using UnityEngine;
using UnityEngine.UI;

public class ControllerDisplayDamage : IController
{
	[SerializeField] private Image _imageBlood;

	private ModelDisplayDamage _model;
	private int _maxAlpha = 100;

	public override void Init(IModel model)
	{
		_model = model as ModelDisplayDamage;

		_model.EntityTarget.EventDamage.AddListener(Handler_DamageEntity);
	}

	private void Handler_DamageEntity()
	{
		var alpha = _model.EntityTarget.Health / _model.MaxHealth;
		_imageBlood.color = new Color(_imageBlood.color.r, _imageBlood.color.g, _imageBlood.color.b, alpha * _maxAlpha);
	}

	public override void Deactive()
	{
		_model.EntityTarget.EventDamage.RemoveListener(Handler_DamageEntity);
		base.Deactive();
	}
}
