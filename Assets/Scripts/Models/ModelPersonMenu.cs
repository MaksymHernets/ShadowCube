using ShadowCube.DTO;

public class ModelPersonMenu : IModel
{
	public PlayerDTO playerDTO { get; }

	public ModelPersonMenu(PlayerDTO player)
	{
		playerDTO = player;
	}
}
