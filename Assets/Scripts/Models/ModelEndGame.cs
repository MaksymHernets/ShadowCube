namespace ShadowCube.Models
{
	public class ModelEndGame : IModel
    {
        public PlayerController playerController { get; set; }
        public float Time { get; set; }
        public float Score { get; set; }
    }
}
