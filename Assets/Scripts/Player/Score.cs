using DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Score : MonoBehaviour
    {
        public Text textRoom;
        public Text textTime;
        public Text textTrap;

        public ScoreCube scoreCube { get; set; }

        public void Start()
        {
            scoreCube = new ScoreCube();
        }

        public void Show()
        {
            textRoom.text = "Rooms: " + scoreCube.Rooms;
            textTime.text = "Time: " + scoreCube.Time;
            textTrap.text = "Traps: " + scoreCube.Traps;
        }
    }
}
