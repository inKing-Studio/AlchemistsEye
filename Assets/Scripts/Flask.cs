using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public enum FlaskType
{
    SMALL = 0,      // 100 mL
    MEDIUM = 1,     // 250 mL
    LARGE = 2,      // 500 mL
    EXTRA_LARGE = 3 //   1  L
}

[CreateAssetMenu(fileName = "Flask", menuName = "AlchemistsEye/New Flask", order = 0)]
public class Flask : ScriptableObject
{
    public FlaskType flaskType;
    public Image imgFlask; // Foreground (colors)
    public Image imgLiquid; // Background (white)

    public int maxLiquidQuantity;
    private int liquidQuantity;
    public int LiquidQuantity
    {
        get { return liquidQuantity; }
        set { liquidQuantity = Random.Range(0, maxLiquidQuantity); }
    }
}
