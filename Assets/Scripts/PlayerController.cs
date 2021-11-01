using ShadowCube.DTO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerLogic playerLogic;

    [SerializeField] private ControllerHUD controllerHUD;
    [SerializeField] private ControllerEndGame controllerEndGame;

    private float timeStartLevel;

    void Start()
    {
        playerLogic.eventDie.AddListener(EventDie_Handler);

        StartLevel();
    }

    public void StartLevel()
	{
        timeStartLevel = 0f;

        var player = new PlayerDTO();
        player.score = new ScoreCube();
        player.Name = "player";
        player.Id = 1;

        playerLogic.Init(player);

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
