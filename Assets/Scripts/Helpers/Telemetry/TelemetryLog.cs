using System;
using System.Collections.Generic;

namespace GoodTime.Helpers.Telemetry
{
	public class TelemetryLog
    {
        public string NameLog;
        public DateTime DataTimeStart;
        public DateTime DataTimeEnd;
        public float CaptureFrequency = 1f;
        public List<AnalyticsDTO> Logs;

        public TelemetryLog(float captureFrequency = 1)
        {
            NameLog = string.Empty;
            CaptureFrequency = captureFrequency;
            Logs = new List<AnalyticsDTO>();
        }

        public void Add(AnalyticsDTO analyticsDTO)
        {
            Logs.Add(analyticsDTO);
        }
    }
}
