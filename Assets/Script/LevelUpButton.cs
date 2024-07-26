using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    private Weapon assignedWeapon;
    public TMP_Text descriptionText, nameText;
    public Image icon;
    public void UpdateButtonDisplay(Weapon currentweapon)
    {
        descriptionText.text = currentweapon.stats[currentweapon.weaponLevel].upgradeText;
        icon.sprite = currentweapon.icon;
        nameText.text = currentweapon.name + "- Lvl" + (currentweapon.weaponLevel + 1);
        assignedWeapon = currentweapon;
    }

    public void SelectUpgrade()
    {
        if (assignedWeapon != null)
        {
            assignedWeapon.LevelUp();
            UIController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
