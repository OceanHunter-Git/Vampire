using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<Weaponstats> stats;
    public int weaponLevel;
    [HideInInspector]
    public bool statsUpdated = false;
    public void LevelUp()
    {
        if (weaponLevel < stats.Count - 1)
        {
            weaponLevel++;
            statsUpdated = true;
        }
    }
}

[System.Serializable]
public class Weaponstats
{
    public float speed, damage, range, timeBetweenSpawn, amount, duration;
}
