using UnityEngine;

namespace ShadowCube
{
	public class ApplicationFocus : MonoBehaviour
    {
        [SerializeField] private KeyCode keyCodePause = KeyCode.Escape;


        private void Update()
		{
            if (Input.GetKeyDown(keyCodePause)) ApplicationFocusSetting.IsPaused = true;
        }

		void OnApplicationFocus(bool hasFocus)
        {
            ApplicationFocusSetting.IsPaused = !hasFocus;
            Cursor.visible = ApplicationFocusSetting.IsPaused;
            if (ApplicationFocusSetting.IsPaused) Cursor.lockState = CursorLockMode.Locked;
            else Cursor.lockState = CursorLockMode.None;
        }
    }

    public static class ApplicationFocusSetting
	{
        public static bool IsPaused = false;
    }
}
