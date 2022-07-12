using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [SerializeField]
    bool state = false;
    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;
    [SerializeField]
    Image child;

    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
        child = transform.GetChild(0).GetComponent<Image>();

        btn.onClick.AddListener(Toggle);

        if (state)
            child.sprite = on;
        else
            child.sprite = off;
    }

    void Toggle()
    {
        state = !state;
        if (state)
            child.sprite = on;
        else
            child.sprite = off;
            
    }
}
