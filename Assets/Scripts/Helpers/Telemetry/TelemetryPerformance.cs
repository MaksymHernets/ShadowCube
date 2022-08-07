using Generic.Convert;
using ShadowCube.Setting;
using System;
using System.Collections;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using Zenject;

namespace GoodTime.Helpers.Telemetry
{
    public class TelemetryPerformance : MonoBehaviour
    {
        public UnityAction<AnalyticsDTO> NewRecord;

        [SerializeField] public TelemetryGUI telemetryGUI;
        [SerializeField] public bool IsTrack_TotalTextureMemory = true;
        [SerializeField] public bool IsShow_DetailTexturesUsed = false;
        
        private ProfilerRecorder _totalReservedMemoryRecorder;
        private ProfilerRecorder _gcReservedMemoryRecorder;
        private ProfilerRecorder _systemUsedMemoryRecorder;

        private float _counterTime = 0;
        private int _counterFrame = 0;
        private float _sumFps = 0;
        private TelemetryLog _telemetryLog;
        private AnalyticsDTO _analyticsDTO;

        private Coroutine coroutine;

        [Inject] GraphicSetting graphicSetting;

        private void Start()
		{
            graphicSetting.ShowFps += ShowFps;

            if ( graphicSetting.showFps )
			{
                Launch();
            }
        }

        public void ShowFps(bool value)
		{
            if ( value )
			{
                Launch();
            }
            else
			{
                Stop();
            }
		}

		public void Launch(float captureFrequency = 1)
        {
            if (coroutine == null)
            {
                _telemetryLog = new TelemetryLog(captureFrequency);
                _telemetryLog.DataTimeStart = DateTime.Now;
                _telemetryLog.NameLog = SceneManager.GetActiveScene().name;

                _totalReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Reserved Memory");
                _gcReservedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory");
                _systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");

                _analyticsDTO = new AnalyticsDTO();
                coroutine = StartCoroutine(UpdateTelemetry());
                telemetryGUI.Show(true);

                Debug.Log("Telemetry started");
            }
            else
			{
                Debug.Log("Telemetry working");
            }
        }

        public TelemetryLog Stop()
        {
            StopCoroutine(coroutine);
            telemetryGUI.Show(false);
            _telemetryLog.DataTimeEnd = DateTime.Now;
            coroutine = null;
            return _telemetryLog;
        }

        private IEnumerator UpdateTelemetry()
        {
            while ( true )
            {
                _counterTime += Time.deltaTime;
                ++_counterFrame;
                _sumFps += 1.0f / Time.unscaledDeltaTime;

                _analyticsDTO.MaximumDeltaTime = Mathf.Max(_analyticsDTO.MaximumDeltaTime, Time.deltaTime);
                _analyticsDTO.MinimumDeltaTime = Mathf.Min(_analyticsDTO.MinimumDeltaTime, Time.deltaTime);

                if (_counterTime >= _telemetryLog.CaptureFrequency)
                {
                    _analyticsDTO.AvgFps = (int)(_sumFps / _counterFrame);
                    _analyticsDTO.AvgDeltaTime = _counterTime / _counterFrame;
                    _analyticsDTO.NumberFrames = _counterFrame;
                    _analyticsDTO.TotalReservedMemory = (int)_totalReservedMemoryRecorder.LastValue.ToConvertDataUnit(DataUnit.MB);
                    _analyticsDTO.TotalSystemUsedMemoryRecorder = (int)_systemUsedMemoryRecorder.LastValue.ToConvertDataUnit(DataUnit.MB);

                    if (IsTrack_TotalTextureMemory)
                    {
                        _analyticsDTO.TotalTextureMemorySize = GetTotalTextureMemorySize();
                    }

                    NewRecord?.Invoke(_analyticsDTO);
                    _telemetryLog.Add(_analyticsDTO);
                    _counterTime = 0;
                    _counterFrame = 0;
                    _sumFps = 0;
                    _analyticsDTO = new AnalyticsDTO();
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private int GetTotalTextureMemorySize()
        {
            int textureCount = 0;
            long totalTextureMemorySizeLong = 0;
            HideFlags hideFlagMask = HideFlags.HideInInspector | HideFlags.HideAndDontSave;
            HideFlags hideFlagMask1 = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy | HideFlags.NotEditable | HideFlags.DontUnloadUnusedAsset;

            var textures = Resources.FindObjectsOfTypeAll(typeof(Texture));
            foreach (Texture t in textures)
            {
                if (t.hideFlags == HideFlags.HideAndDontSave || t.hideFlags == hideFlagMask || t.hideFlags == hideFlagMask1)
                    continue;

                ++textureCount;
                long memoryUsed = Profiler.GetRuntimeMemorySizeLong(t);
                if (IsShow_DetailTexturesUsed)
                    Debug.Log("Texture: " + t.name + " : hideFlags: " + t.hideFlags.ToString() + ": Memory: " + memoryUsed.ToConvertDataUnit(DataUnit.MB), this);

                totalTextureMemorySizeLong += memoryUsed;
            }
            int totalTextureMemorySize = (int)totalTextureMemorySizeLong.ToConvertDataUnit(DataUnit.MB);
            return totalTextureMemorySize;
        }

        private void OnDestroy()
        {
            _totalReservedMemoryRecorder.Dispose();
            _gcReservedMemoryRecorder.Dispose();
            _systemUsedMemoryRecorder.Dispose();
        }
    }
}
