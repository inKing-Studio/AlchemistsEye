using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.Linq;

public class Level : MonoBehaviour {

    [SerializeField]
    FlaskScriptable[] availableFlasks;

    // GUI
    public Slider guessSlider;
    public Button guessButton;
    public TextMeshProUGUI guessText;
    public int levelStars; // 0 - 3

    public Flask[] uiFlasks;

    [SerializeField]
    int minSliderValue, maxSliderValue;
    [SerializeField]
    int totalLiquid;

    void Start() {
        minSliderValue = 0;
        maxSliderValue = 0;
        totalLiquid = 0;

        int difLevel = PlayerPrefs.GetInt("LevelDifficulty");
        Debug.Log(difLevel);
        for (int i = 0; i < difLevel && i < uiFlasks.Length; i++)
        {
            uiFlasks[i].gameObject.SetActive(true);
            uiFlasks[i].Setup();

            totalLiquid += uiFlasks[i].Liquid;
            maxSliderValue += uiFlasks[i].MaxLiquid;
        }

        guessSlider.minValue = minSliderValue;
        guessSlider.maxValue = maxSliderValue;
        guessSlider.value = AverageIntValue(minSliderValue, maxSliderValue);
        guessButton.interactable = true;
        guessText.text = guessSlider.value.ToString();
    }
    
    public int AverageIntValue(float value, float value2)
    {
        return (int)Mathf.Round((value + value2) / 2);
    }

    public void OnGuessButtonClicked() {
        if (guessSlider.value >= totalLiquid * .9f || guessSlider.value <= totalLiquid * 1.1f)
        {
            levelStars = 3;
        }
        else if(guessSlider.value > totalLiquid * .7f || guessSlider.value < totalLiquid * 1.3f)
        {
            levelStars = 2;
        }
        else if(guessSlider.value > totalLiquid * .5f || guessSlider.value < totalLiquid * 1.5f)
        {
            levelStars = 1;
        }
        else
        {
            levelStars = 0;
        }

        Debug.Log("Stars: " + levelStars);
        guessSlider.interactable = false;
        guessButton.interactable = false;
    }

    public void OnSliderValueChanged()
    {
        guessText.text = guessSlider.value.ToString();
    }
}
