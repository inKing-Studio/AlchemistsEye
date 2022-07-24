using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<Flask> flasks; // 1 - 3

    private int minSliderValue, maxSliderValue;
    public int MinSliderValue
    {
        get { return ; }
        set { minSliderValue = value; }
    }
    public int MaxSliderValue
    {
        get { return ; }
        set { maxSliderValue = value; }
    }

    private int totalLiquid;
    public int TotalLiquid
    {
        get { return totalLiquid; }
        set { totalLiquid = value; }
    }

    public void Awake()
    {
        flasks = new List<Flask>();
    }

    public void CalculateTotalLiquid()
    {
        int liquid = 0;

        foreach (Flask flask in flasks)
        {
            flask.LiquidQuantity = Random.Range(0, flask.maxLiquidQuantity);
            liquid += flask.LiquidQuantity;
        }
    }

    public void SetSliderValues()
    {
        MinSliderValue = Mathf.RoundToInt(Random.Range(0f, .25f) * TotalLiquid);
        MaxSliderValue = Mathf.RoundToInt(Random.Range(2.00f, 2.50f) * TotalLiquid);
        guessSlider.value = AverageIntValue(MinSliderValue, MaxSliderValue);
        guessText.text = guessSlider.value.ToString();
    }
}
