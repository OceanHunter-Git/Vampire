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
        if (currentweapon.gameObject.activeSelf)
        {
            descriptionText.text = currentweapon.stats[currentweapon.weaponLevel].upgradeText;
            icon.sprite = currentweapon.icon;
            nameText.text = currentweapon.name + "- Lvl" + (currentweapon.weaponLevel + 1);
        }
        else
        {
            descriptionText.text = "Unlocl " + currentweapon.name;
            icon.sprite = currentweapon.icon;
            nameText.text = currentweapon.name;

        }
        assignedWeapon = currentweapon;
    }

    public void SelectUpgrade()
    {
        if (assignedWeapon != null)
        {
            if (assignedWeapon.gameObject.activeSelf)
            {
                assignedWeapon.LevelUp();
            }
            else
            {
                PlayerController.instance.AddWeapon(assignedWeapon);
            }
            UIController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
