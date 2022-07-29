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
public class FlaskScriptable : ScriptableObject
{
    public Sprite imgFlask;  // Foreground (colors)
    public Sprite imgLiquid; // Background (white)

    public int maxLiquidQuantity;

}
