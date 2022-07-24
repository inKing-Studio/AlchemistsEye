using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGenerator : MonoBehaviour {
    public Slider guessSlider;
    public Button guessButton;
    public TextMeshProUGUI guessText;
    public int levelStars; // 0 - 3

    private Color[] liquidColors; // Liquid color

    void Awake() {
        guessSlider.minValue = level.MinSliderValue;
        guessSlider.maxValue = level.MaxSliderValue;
        guessSlider.value = AverageIntValue(level.MinSliderValue, level.MaxSliderValue);
        guessButton.interactable = true;
        guessText.text = guessSlider.value.ToString();
    }
    
    public int AverageIntValue(float value, float value2)
    {
        return (int)Mathf.Round((value + value2) / 2);
    }

    public void OnGuessButtonClicked() {
        if (guessSlider.value >= level.TotalLiquid * .9f || guessSlider.value <= level.TotalLiquid * 1.1f)
        {
            levelStars = 3;
            guessSlider.interactable = false;
            guessButton.interactable = false;
        }
        else if(guessSlider.value > level.TotalLiquid * .7f || guessSlider.value < level.TotalLiquid * 1.3f)
        {
            levelStars = 2;
            guessSlider.interactable = false;
            guessButton.interactable = false;
        }
        else if(guessSlider.value > level.TotalLiquid * .5f || guessSlider.value < level.TotalLiquid * 1.5f)
        {
            levelStars = 1;
            guessSlider.interactable = false;
            guessButton.interactable = false;
        }
        else
        {
            levelStars = 0;
            guessSlider.interactable = false;
            guessButton.interactable = false;
        }
    }

    public void OnSliderValueChanged()
    {
        guessText.text = guessSlider.value.ToString();
    }

    void Start()
    {        
        // GenerateLevel();
    }

    public void GenerateLevel()
    {
        int difLevel = PlayerPrefs.GetInt("LevelDifficulty"); // 1 - Easy, 2 - Medium, 3 - Hard
        liquidColors = new Color[] { Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta, Color.white, Color.black, Color.gray };
        for(int i = 0; i < difLevel; i++)
        {
            flasks[i].liquidColor = liquidColors[Random.Range(0, liquidColors.Length)];
            flasks[i].LiquidQuantity = Random.Range(0, MaxLiquidQuantity);
        }
        PlaceLevel(difLevel);
    }
 
    public void PlaceLevel(int difLevel)
    {
        switch (difLevel)
        {
            case 1:
                flasks[0].imgFlask.rectTransform.anchoredPosition = new Vector2(0, 64);
                flasks[0].imgLiquid.rectTransform.anchoredPosition = new Vector2(0, 64);
                flasks[0].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                flasks[0].imgLiquid.fillAmount = flasks[0].LiquidQuantity / flasks[0].maxLiquidQuantity;
                break;

            case 2:
                for(int i = 0; i < 2; i++)
                {
                    flasks[i].imgFlask.rectTransform.anchoredPosition = new Vector2(-128 + 256 * i, 64);
                    flasks[i].imgLiquid.rectTransform.anchoredPosition = new Vector2(-128 + 256 * i, 64);
                    flasks[i].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                    flasks[i].imgLiquid.fillAmount = flasks[i].LiquidQuantity / flasks[i].maxLiquidQuantity;
                }
                break;

            case 3:
                for (int i = 0; i < 3; i++)
                {
                    flasks[i].imgFlask.rectTransform.anchoredPosition = new Vector2(-256 + 256 * i, 64);
                    flasks[i].imgLiquid.rectTransform.anchoredPosition = new Vector2(-256 + 256 * i, 64);
                    flasks[i].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                    flasks[i].imgLiquid.fillAmount = flasks[i].LiquidQuantity / flasks[i].maxLiquidQuantity;
                }
                break;
        }

        guessText.text = guessSlider.value.ToString();

        int totalLiquid = 0;

        for (int i = 0; i < flasks.Length; i++)
        {
            totalLiquid += flasks[i].LiquidQuantity;
        }
    }
}
