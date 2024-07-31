using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public TMP_Text timeText;
    public GameObject levelEndScreen;
    public TMP_Text endTimeText;
    public string menuName;
    public GameObject pauseScreen;

    public PlayerStatsUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickUpRangeUpgradeDisplay, maxWeaponUpgradeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseUnpause();
        }    
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

    public void UpdateTime(float time)
    {
        float minute = Mathf.FloorToInt(time / 60f);
        float second = Mathf.FloorToInt(time % 60f);
        timeText.text = "Time: " + minute + ":" + second.ToString("00");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuName);
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseUnpause()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            if (levelUpPanel.activeSelf == false)
            {
            Time.timeScale = 1;
            }
        }
    }
}
