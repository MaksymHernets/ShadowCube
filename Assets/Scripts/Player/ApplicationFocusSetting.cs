using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ShadowCube
{
    public class ApplicationFocusSetting : MonoBehaviour
    {
        public static bool IsPaused = false;

        [SerializeField] private KeyCode keyCode = KeyCode.Escape;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (Cursor.lockState == CursorLockMode.None ) IsPaused = true;
        }
    }
}
