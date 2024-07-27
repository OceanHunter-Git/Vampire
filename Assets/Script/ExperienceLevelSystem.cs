using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExperienceLevelSystem : MonoBehaviour
{
    public static ExperienceLevelSystem instance;
    public ExpPickUp pickUpExp;
    private void Awake()
    {
        instance = this;
    }

    public List<Weapon> weaponToUpgrade;
    public int currentExperience;
    public int currentLevel;
    public int levelCount;
    public List<int> level;
    // Start is called before the first frame update
    void Start()
    {
        while (level.Count < levelCount)
        {
            level.Add(Mathf.CeilToInt(level[level.Count - 1] * 1.1f));
        }        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void GetExp(int experienceToGet)
    {
        currentExperience += experienceToGet;
        while (currentExperience >= level[currentLevel])
        {
            LevelUp();
        }
        UIController.instance.UpdateExp(currentExperience, level[currentLevel], currentLevel);
    }

    public void SpawnExp (Vector3 Location, int expAmount)
    {
        Instantiate(pickUpExp, Location, Quaternion.identity).expValue = expAmount;
    }
    private void LevelUp()
    {
        currentExperience -= level[currentLevel];

        currentLevel++;

        if (currentLevel > levelCount)
        {
            currentLevel--;
        }

        UIController.instance.levelUpPanel.SetActive(true);
        Time.timeScale = 0f;

        //UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.activeWeapon);
        //UIController.instance.levelUpButtons[0].UpdateButtonDisplay(PlayerController.instance.assignedWeapons[0]);
        //UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[0]);
        //UIController.instance.levelUpButtons[2].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[1]);
        weaponToUpgrade.Clear();
        List<Weapon> availableWeapons = new List<Weapon>();
        availableWeapons.AddRange(PlayerController.instance.assignedWeapons);

        if (availableWeapons.Count > 0)
        {
            int selected = Random.Range(0, availableWeapons.Count);
            weaponToUpgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        if (PlayerController.instance.assignedWeapons.Count + PlayerController.instance.fullyLevelWeapons.Count < PlayerController.instance.maxWeapons)
        {
            availableWeapons.AddRange(PlayerController.instance.unassignedWeapons);
        }
        
        for (int i = weaponToUpgrade.Count; i < 3; i++)
        {
            if (availableWeapons.Count > 0)
            {
                int selected = Random.Range(0, availableWeapons.Count);
                weaponToUpgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
        }

        for (int i = 0; i < weaponToUpgrade.Count; i++)
        {
            UIController.instance.levelUpButtons[i].UpdateButtonDisplay(weaponToUpgrade[i]);
        }

        for (int i = 0; i < UIController.instance.levelUpButtons.Count(); i++)
        {
            if (i < weaponToUpgrade.Count)
            {
                UIController.instance.levelUpButtons[i].gameObject.SetActive(true);
            }
            else
            {
                UIController.instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }
    }
}
