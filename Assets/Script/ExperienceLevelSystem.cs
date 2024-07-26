using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelSystem : MonoBehaviour
{
    public static ExperienceLevelSystem instance;
    public ExpPickUp pickUpExp;
    private void Awake()
    {
        instance = this;
    }

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

        UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.activeWeapon);
    }
}
