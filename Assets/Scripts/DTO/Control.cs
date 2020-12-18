using UnityEngine;

namespace DTO
{
    public class Control
    {
        public int id { set; get; }
        public KeyCode jump { set; get; }
        public KeyCode forward { set; get; }
        public KeyCode back { set; get; }
        public KeyCode left { set; get; }
        public KeyCode right { set; get; }
        public KeyCode use { set; get; }
        public KeyCode openitem { set; get; }
        public KeyCode sitdown { set; get; }
    }
}
