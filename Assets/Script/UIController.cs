using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject levelUpPanel;
    public LevelUpButton[] levelUpButtons;
    public Slider expSlider;
    public TMP_Text expText;
    public TMP_Text coinText;

    public PlayerStatsUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickUpRangeUpgradeDisplay, maxWeaponUpgradeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateExp(int currentExp, int levelExp, int level)
    {
        expSlider.maxValue = levelExp;
        expSlider.value = currentExp;

        expText.text = "Level: " + level.ToString();
    }

    public void UpdateCoin()
    {
        coinText.text = "Coins:" + CoinController.instance.coinCounter;
    }

    public void SkipUpgrade()
    {
        UIController.instance.levelUpPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void PurchaseMoveSpeed()
    {
        PlayerStatsController.instance.PurchaseMoveSpeed();
        SkipUpgrade();
    }
    public void PurchaseHealth()
    {
        PlayerStatsController.instance.PurchaseHealth();
        SkipUpgrade();
    }
    public void PurchasePickUpRange()
    {
        PlayerStatsController.instance.PurchasePickUpRange();
        SkipUpgrade();
    }
    public void PurchaseMaxWeapon()
    {
        PlayerStatsController.instance.PurchaseMaxWeapon();
        SkipUpgrade();
    }
}
