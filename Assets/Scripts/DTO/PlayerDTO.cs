using Playerr;
using System;
using UnityEngine;

namespace ShadowCube.DTO
{
	public class PlayerDTO
    {
        public string Name;
        public Guid ID;
        public int Gender;
        public Inventory inventory;
        public ScoreCube score;

        public PlayerDTO()
		{
            Name = "Nomad";
            ID = Guid.NewGuid();
            Gender = 0;
            inventory = new Inventory(10);
            score = new ScoreCube();
        }
    }

}
