using Playerr;

namespace ShadowCube.DTO
{
	public class PlayerDTO
    {
        public string Name;
        public int Id;
        public bool Sex;
        public Inventory inventory;
        public ScoreCube score;

        public PlayerDTO()
		{
            inventory = new Inventory(10);
            score = new ScoreCube();
        }
    }
}
