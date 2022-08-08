using UnityEngine;

namespace GoodTime.Helpers.Telemetry
{
    public class TelemetryGUI : MonoBehaviour
    {
        [SerializeField] private TelemetryPerformance _telemetry;

        [SerializeField] private KeyCode KeyCodeShowTerminal = KeyCode.P;
        [SerializeField] private bool ShowTerminal = true;

        private AnalyticsDTO _currentAnalyticsDTO;
        private GUIStyle GUIStyle;

        private float Font = 20;
        private const float Default_WidthScreen = 1920f;
        private const float Default_HeightScreen = 1080f;

        private void Start()
        {
            _currentAnalyticsDTO = new AnalyticsDTO();
            _telemetry.NewRecord += Handler_NewLog;

            float scaleWidth = Default_WidthScreen / Screen.width;
            float scaleHeight = Default_HeightScreen / Screen.height;
            float avgScale = (scaleWidth + scaleHeight) / 2;

            GUIStyle = new GUIStyle();
            GUIStyle.fontSize = (int)(Font * avgScale);
        }

        public void Show(bool key = true)
		{
            gameObject.SetActive(key);
		}

        private void Handler_NewLog(AnalyticsDTO analyticsDTO)
        {
            _currentAnalyticsDTO = analyticsDTO;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCodeShowTerminal))
            {
                ShowTerminal = !ShowTerminal;
            }
        }

        private void OnGUI()
        {
            GUILayout.Label(_currentAnalyticsDTO.ToString());
        }

        private void OnDestroy()
        {
            _telemetry.NewRecord -= Handler_NewLog;
        }
    }
}
