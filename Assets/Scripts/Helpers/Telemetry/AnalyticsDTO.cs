using System.Text;

namespace GoodTime.Helpers.Telemetry
{
	public class AnalyticsDTO
    {
        public int AvgFps = 0;
        public int NumberFrames = 0;
        public float AvgDeltaTime = 0;
        public float MinimumDeltaTime = float.MaxValue;
        public float MaximumDeltaTime = 0;
        public int TotalReservedMemory = 0;
        public int TotalTextureMemorySize = 0;
        public int TotalSystemUsedMemoryRecorder = 0;

        public override string ToString()
        {
            var sb = new StringBuilder(500);
            sb.AppendLine($"Avg FPS: {AvgFps}");
            sb.AppendLine($"Number Frames: {NumberFrames}");
            sb.AppendLine($"Avg Delta Time: {AvgDeltaTime} ms");
            sb.AppendLine($"Minimum Delta Time: {MinimumDeltaTime} ms");
            sb.AppendLine($"Maximum Delta Time: {MaximumDeltaTime} ms");
            sb.AppendLine($"Total Reserved Memory: {TotalReservedMemory} MB");
            sb.AppendLine($"Total Texture Memory Size: {TotalTextureMemorySize} MB");
            sb.AppendLine($"TotalSystemUsedMemoryRecorder: {TotalSystemUsedMemoryRecorder} MB");
            return sb.ToString();
        }
    }
}
