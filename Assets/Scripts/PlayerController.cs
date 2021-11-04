using ShadowCube.DTO;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    [SerializeField] private ControllerHUD controllerHUD;
    [SerializeField] private ControllerEndGame controllerEndGame;

    private float timeStartLevel;

    [Inject] GameSetting gameSetting;

    void Start()
    {
        playerLogic.EventDie.AddListener(EventDie_Handler);

        StartLevel();
    }

    public void StartLevel()
	{
        timeStartLevel = 0f;

        playerLogic.Init(gameSetting.playerDTO);

        controllerHUD.Init(new ModelHUD());
    }

	private void Update()
	{
        timeStartLevel += Time.deltaTime;
    }

	private void EventDie_Handler()
	{
        ModelEndGame model = new ModelEndGame();
        model.Time = timeStartLevel;

        controllerEndGame.Init(model);
    }
}
