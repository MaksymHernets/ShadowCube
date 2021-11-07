using ShadowCube.DTO;
using ShadowCube.Setting;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    [Header("Controllers")]
    [SerializeField] private ControllerEndGame controllerEndGame;
    [SerializeField] private ControllerHUD controllerHUD;
    [SerializeField] private ControllerMenu controllerMenu;
    [SerializeField] private ControllerDisplayDamage controllerDisplayDamage;

    private float timeStartLevel;

    [Inject] GameSetting gameSetting;

    void Start()
    {
        playerLogic.EventDie.AddListener(EventDie_Handler);

        controllerMenu.EventOpenedMenu.AddListener(EventOpenedMenu_Handler);
        controllerMenu.EventClosedMenu.AddListener(EventClosedMenu_Handler);

        StartLevel();
    }

	public void StartLevel()
	{
        timeStartLevel = 0f;

        playerLogic.Init(gameSetting.playerDTO);

        controllerEndGame.Init(new ModelEndGame() { playerController = this});
        controllerHUD.Init(new ModelHUD() { playerLogic = playerLogic } );
        controllerMenu.Init(new IModel());
        controllerDisplayDamage.Init(new ModelDisplayDamage() { EntityTarget = playerLogic });
    }

	private void Update()
	{
        timeStartLevel += Time.deltaTime;
    }

    private void EventClosedMenu_Handler()
    {
        controllerHUD.Init(new ModelHUD() { playerLogic = playerLogic });
    }

    private void EventOpenedMenu_Handler()
	{
        controllerHUD.Deactive();
    }

	private void EventDie_Handler()
	{
        ModelEndGame model = new ModelEndGame();
        model.Time = timeStartLevel;

        controllerEndGame.Init(model);
    }
}
