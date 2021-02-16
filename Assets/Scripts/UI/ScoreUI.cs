using DTO;
using ShadowCube.DTO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShadowCube.UI
{
    public class ScoreUI : MonoBehaviour
    {
        public Text textRoom;
        public Text textTime;
        public Text textTrap;

        public void Show(ScoreCube scoreCube)
        {
            gameObject.SetActive(true);
            textRoom.text = "Rooms: " + scoreCube.Rooms;
            textTime.text = "Time: " + scoreCube.Time + " sec";
            textTrap.text = "Traps: " + scoreCube.Traps;
        }
    }
}
