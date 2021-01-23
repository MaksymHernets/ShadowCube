using Playerr;
using ShadowCube.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShadowCube.DTO
{
    public class Player : PlayerBase
    {
        public float xp;

        public Inventory inventory;
        public ScoreCube score;

        public Player()
		{
            xp = 100;
            inventory = new Inventory(10);
            score = new ScoreCube();
        }
    }
}
