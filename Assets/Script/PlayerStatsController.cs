using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public static PlayerStatsController instance;

    private void Awake()
    {
        instance = this;
    }

    public List<PlayerStatValue> moveSpeed, health, pickupRange, maxWeapon;
    public int moveSpeedLevelCount, healthLevelCount, pickupRangeLevelCount;
    private int moveSpeedLevel, healthLevel, pickupRangeLevel, maxWeaponLevel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = moveSpeed.Count - 1; i < moveSpeedLevelCount; i++)
        {
            moveSpeed.Add(new PlayerStatValue(moveSpeed[i].cost + moveSpeed[1].cost, moveSpeed[i].value + (moveSpeed[1].value - moveSpeed[0].value)));
        }
        for (int i = health.Count - 1; i < healthLevelCount; i++)
        {
            health.Add(new PlayerStatValue(health[i].cost + health[1].cost, health[i].value + (health[1].value - health[0].value)));
        }
        for (int i = pickupRange.Count - 1; i < pickupRangeLevelCount; i++)
        {
            pickupRange.Add(new PlayerStatValue(pickupRange[i].cost + pickupRange[1].cost, pickupRange[i].value + (pickupRange[1].value - pickupRange[0].value)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UIController.instance.levelUpPanel.activeSelf)
        {
            UpgradeDisplay();
        }    
    }

    public void UpgradeDisplay()
    {
        if (moveSpeedLevel < moveSpeed.Count - 1)
        {
            UIController.instance.moveSpeedUpgradeDisplay.UpdateDisplay(moveSpeed[moveSpeedLevel + 1].cost, moveSpeed[moveSpeedLevel].value, moveSpeed[moveSpeedLevel + 1].value);
        }
        else
        {
            UIController.instance.moveSpeedUpgradeDisplay.ShowMaxLevel();
        }

        if (healthLevel < health.Count - 1)
        {
            UIController.instance.healthUpgradeDisplay.UpdateDisplay(health[healthLevel + 1].cost, health[healthLevel].value, health[healthLevel + 1].value);
        }
        else
        {
            UIController.instance.healthUpgradeDisplay.ShowMaxLevel();
        }

        if (pickupRangeLevel < pickupRange.Count - 1)
        {
            UIController.instance.pickUpRangeUpgradeDisplay.UpdateDisplay(pickupRange[pickupRangeLevel + 1].cost, pickupRange[pickupRangeLevel].value, pickupRange[pickupRangeLevel + 1].value);
        }
        else
        {
            UIController.instance.pickUpRangeUpgradeDisplay.ShowMaxLevel();
        }
        if (maxWeaponLevel < maxWeapon.Count - 1)
        {
            UIController.instance.maxWeaponUpgradeDisplay.UpdateDisplay(maxWeapon[maxWeaponLevel + 1].cost, maxWeapon[maxWeaponLevel].value, maxWeapon[maxWeaponLevel + 1].value);
        }
        else
        {
            UIController.instance.maxWeaponUpgradeDisplay.ShowMaxLevel();
        }  
    }
    public void PurchaseMoveSpeed()
    {
        moveSpeedLevel++;
        CoinController.instance.SpendCoin(moveSpeed[moveSpeedLevel].cost);
        UpgradeDisplay();
        PlayerController.instance.moveSpeed = moveSpeed[moveSpeedLevel].value;
    }
    public void PurchaseHealth()
    {
        healthLevel++;
        CoinController.instance.SpendCoin(health[healthLevel].cost);
        UpgradeDisplay();
        PlayerHealthController.instance.maxHealth = health[healthLevel].value;
        PlayerHealthController.instance.currentHealth += health[healthLevel].value - health[healthLevel - 1].value;
    }
    public void PurchasePickUpRange()
    {
        pickupRangeLevel++;
        CoinController.instance.SpendCoin(pickupRange[pickupRangeLevel].cost);
        UpgradeDisplay();
        PlayerController.instance.pickUpRange = pickupRange[pickupRangeLevel].value;
    }
    public void PurchaseMaxWeapon()
    {
        maxWeaponLevel++;
        CoinController.instance.SpendCoin(maxWeapon[maxWeaponLevel].cost);
        UpgradeDisplay();
        PlayerController.instance.maxWeapons = Mathf.RoundToInt(maxWeapon[maxWeaponLevel].value);
    }

}
[System.Serializable]
public class PlayerStatValue
{
    public int cost;
    public float value;
    public PlayerStatValue(int newcost, float newValue)
    {
        cost = newcost;
        value = newValue;
    }
}
