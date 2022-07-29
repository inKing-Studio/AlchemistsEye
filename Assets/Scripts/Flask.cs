using UnityEngine;
using UnityEngine.UI;

public class Flask : MonoBehaviour
{
    public FlaskScriptable[] availableFlasks;

    bool set = false;
    int liquid;
    int maxLiquid;

    [SerializeField]
    Image uiFlask;
    [SerializeField]
    Image uiLiquid;

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

        var flask = availableFlasks.PickRandom();
        uiFlask.sprite = flask.imgFlask;
        uiLiquid.sprite = flask.imgLiquid;
        maxLiquid = flask.maxLiquidQuantity;

        liquid = Random.Range(0, maxLiquid);
        uiLiquid.fillAmount = (float)liquid / maxLiquid;
        uiLiquid.color = liquidColors.PickRandom();

        set = true;
    }
}
