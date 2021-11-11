using UnityEngine;

namespace ShadowCube.DTO
{
    public class ControlPC
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

        public ControlPC()
		{
            jump = KeyCode.Space;
            forward = KeyCode.W;
            back = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
            use = KeyCode.E;
            openitem = KeyCode.Tab;
            sitdown = KeyCode.LeftControl;
        }
    }
}
