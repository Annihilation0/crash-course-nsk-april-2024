﻿namespace Market.Misc;

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double minValue, double maxValue)
    {
        return random.NextDouble() * (maxValue - minValue) + minValue;
    }
}