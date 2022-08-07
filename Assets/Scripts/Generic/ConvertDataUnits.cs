using System;

namespace Generic.Convert
{
	public static class ConvertDataUnits
    {
        public static Int64 ToConvertDataUnit(this Int64 value, DataUnit ToUnit)
        {
            if (value == 0) return 0;
            return (int)(value / (double)Math.Pow(1024, (Int64)ToUnit));
        }

        // No Test
        public static Int64 ToConvertDataUnit(this Int64 value, DataUnit currentUnit, DataUnit ToUnit)
        {
            if (value == 0) return 0;
            if (currentUnit == ToUnit) return value;
            if (currentUnit == DataUnit.Bit)
            {
                value /= 8;
                currentUnit = DataUnit.Byte;
            }
            int k = (int)ToUnit - (int)currentUnit;
            return (int)(value / (double)Math.Pow(1024, k));
        }
    }

    public enum DataUnit
    {
        Byte, KB, MB, GB, TB, PB, EB, ZB, YB, Bit
    }
}
