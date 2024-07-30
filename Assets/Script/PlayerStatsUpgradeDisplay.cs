using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUpgradeDisplay : MonoBehaviour
{
    public TMP_Text valueText, costText;

    public GameObject button;

    public void UpdateDisplay(int cost, float oldvalue, float newvalue)
    {
        valueText.text = "Value: " + oldvalue.ToString("F1") + "->" + newvalue.ToString("F1");
        costText.text = "Cost: " + cost;

        if (cost <= CoinController.instance.coinCounter)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void ShowMaxLevel()
    {
        valueText.text = "Max Level";
        costText.text = "Max Level";
        button.SetActive(false);
    }
}
