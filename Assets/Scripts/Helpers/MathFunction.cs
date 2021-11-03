public static class MathFunction
{
    public static bool IsSimpleNumber(int n)
    {
        if (n > 1)
        {
            for (int i = 2; i < n; ++i)
                if (n % i == 0)
                    return false;
            return true;
        }
        else
            return false;
    }

    public static int SumNumber(int value)
    {
        int value1 = value % 10;
        int value2 = ((value % 100) - value1) / 10;
        int value3 = ((value % 1000) - value2) / 100;
        return value1 + value2 + value3;
    }
}
