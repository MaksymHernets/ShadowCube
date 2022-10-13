using UnityEngine;

namespace ShadowCube
{
	public class CameraTarget : MonoBehaviour
    {
        [SerializeField] private GameObject target;
        [SerializeField] private GameObject mainCamera;

        public bool IsLook = true;
        public bool IsBind
        {
            get
            {
                return isBind;
            }
            set
            {
                isBind = value;
                ShiftX = target.transform.localEulerAngles.y;
            }
        }
        public float ShiftY
        {
            get
            {
                return shiftY;
            }
            set
            {
                float temp = shiftY + value;
                if (value < 60 && value > -20)
                    shiftY = value;
            }
        }
        public float Scroll
        {
            get
            {
                return scroll;
            }
            set
            {
                if (value < 4 && value > 1)
                    scroll = value;
            }
        }

        public float ShiftX = 0f;

        private float scroll = 1f;
        private float shiftY = 1f;
        private Vector3 vectorDefault;
        private bool isBind = false;

        private void Start()
        {
            vectorDefault = mainCamera.transform.localPosition;
        }

        void Update()
        {
            if (ApplicationFocusSetting.IsPaused) return;

            Vector3 position = SimpleMouse.GetPosition();

            ShiftY += position.x;

            if (IsLook) this.transform.position = target.transform.position;
            if (IsBind)
            {
                this.transform.eulerAngles = target.transform.localEulerAngles + new Vector3(ShiftY, 0, 0);
            }
            else
            {
                ShiftX += position.y;
                this.transform.eulerAngles = new Vector3(ShiftY, ShiftX, 0);
            }

            ScrollCamera();
        }

        private void ScrollCamera()
        {
            if (Input.mouseScrollDelta.y != 0)
            {
                Scroll -= Input.mouseScrollDelta.y * 0.1f;
                mainCamera.transform.localPosition = vectorDefault * Scroll;
            }
        }
    }
}
