using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Flask : MonoBehaviour
{
    public FlaskScriptable[] availableFlasks;

    bool set = false;
    int liquid;
    int maxLiquid;

    [SerializeField]
    Image uiFlask, uiLiquid;

    [SerializeField]
    Color[] liquidColors;

    public int Liquid => liquid;
    public int MaxLiquid => maxLiquid;

    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    public void Setup()
    {
        if (set)
            return;

        // System.Func<int, int, int> betterRandom = (min, max) => {
        //     var bytes = new byte[1];
        //     rng.GetBytes(bytes);
        //     return min + bytes[0] % (max - min);
        // };
        

        var flask = availableFlasks.PickRandom(BetterRandom);
        uiFlask.sprite = flask.imgFlask;
        uiLiquid.sprite = flask.imgLiquid;
        maxLiquid = flask.maxLiquidQuantity;

        liquid = BetterRandom(5, maxLiquid);
        var linearAmount = (float)liquid / maxLiquid;
        Debug.Log("Content: " + liquid);

        uiLiquid.fillAmount = flask.fillCurve.Evaluate(linearAmount);
        uiLiquid.color = liquidColors.PickRandom(BetterRandom);

        set = true;
    }

    // int BetterRandom(int min, int max){
    //     var rng = RandomNumberGenerator.Create();
    //     var bytes = new byte[11];
    //     rng.GetBytes(bytes);

    //     int i = bytes[8] % 8;
    //     int j = bytes[9] % 8;
    //     int xored = bytes[i] ^ bytes[j] / bytes[10];
    //     return min + xored % (max - min);
    // }

    int BetterRandom(int min, int max){
        int times = Random.Range(1, 5);
        int value = 0;
        for (int i = 0; i < times; i++)
            value = Random.Range(min, max);

        return value;
    }

    int AverageRandom(int min, int max){
        int times = Random.Range(1, 5);
        int value = 0;
        for (int i = 0; i < times; i++)
            value += Random.Range(min, max);
        
        return value / times;
    }
}
