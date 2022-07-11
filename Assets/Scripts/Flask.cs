using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/* Flask Sizes
    SMALL,      //  100 mL
    MEDIUM,     //  400 mL
    LARGE,      //  700 mL
    EXTRA_LARGE // 1200 mL
*/

[CreateAssetMenu(fileName = "Flask", menuName = "AlchemistsEye/New Flask", order = 0)]
public class Flask : ScriptableObject
{
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
