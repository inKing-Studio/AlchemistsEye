using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public Flask[] flasks; // 1 - 3
    private int minSliderValue, maxSliderValue;
    public int MinSliderValue
    {
        get { return minSliderValue; }
        set { minSliderValue = Mathf.RoundToInt(Random.Range(0f, .25f) * TotalLiquid); }
    }
    public int MaxSliderValue
    {
        get { return maxSliderValue; }
        set { maxSliderValue = Mathf.RoundToInt(Random.Range(2.00f, 2.50f) * TotalLiquid); }
    }
    private int totalLiquid;
    public int TotalLiquid
    {
        get
        {
            return totalLiquid;
        }
        set
        {
            if(totalLiquid <= 0)
            {
                foreach (Flask flask in flasks)
                {
                    totalLiquid += flask.LiquidQuantity;
                }
            }
        }
    }
}
