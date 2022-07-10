using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelGenerator : MonoBehaviour {
    public Level level; // Scriptable object que contiene los datos del nivel (numero de frascos, tipo de frasco y color del liquido de cada frasco)
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

    void Start()
    {        
        // GenerateLevel();
    }

    public void OnSliderValueChanged() {
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

    public Level GenerateLevel()
    {
        switch (level.flasks.Length)
        {
            case 1:
                level.flasks[0].imgFlask.rectTransform.anchoredPosition = new Vector2(0, 64);
                level.flasks[0].imgLiquid.rectTransform.anchoredPosition = new Vector2(0, 64);
                level.flasks[0].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                level.flasks[0].imgLiquid.fillAmount = level.flasks[0].LiquidQuantity / level.flasks[0].maxLiquidQuantity;
                break;

            case 2:
                for(int i = 0; i < 2; i++)
                {
                    level.flasks[i].imgFlask.rectTransform.anchoredPosition = new Vector2(-128 + 256 * i, 64);
                    level.flasks[i].imgLiquid.rectTransform.anchoredPosition = new Vector2(-128 + 256 * i, 64);
                    level.flasks[i].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                    level.flasks[i].imgLiquid.fillAmount = level.flasks[i].LiquidQuantity / level.flasks[i].maxLiquidQuantity;
                }
                break;

            case 3:
                for (int i = 0; i < 3; i++)
                {
                    level.flasks[i].imgFlask.rectTransform.anchoredPosition = new Vector2(-256 + 256 * i, 64);
                    level.flasks[i].imgLiquid.rectTransform.anchoredPosition = new Vector2(-256 + 256 * i, 64);
                    level.flasks[i].imgLiquid.color = liquidColors[Random.Range(0, liquidColors.Length)];
                    level.flasks[i].imgLiquid.fillAmount = level.flasks[i].LiquidQuantity / level.flasks[i].maxLiquidQuantity;
                }
                break;
        }

        guessText.text = guessSlider.value.ToString();
        guessSlider.transform.position = new Vector2(0, -256);
        guessButton.transform.position = new Vector2(0, -320);

        int totalLiquid = 0;

        for (int i = 0; i < level.flasks.Length; i++)
        {
            totalLiquid += level.flasks[i].LiquidQuantity;
        }

        return level;
    }
}
