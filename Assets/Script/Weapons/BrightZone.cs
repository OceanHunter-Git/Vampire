using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightZone : Weapon
{
    public EnemyDamage enmeyDamage;


    private float spawnWaitTime;
    private float spawnCountDown;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    void SetStats()
    {
        enmeyDamage.timeBetweenDamage = stats[weaponLevel].speed;

        transform.localScale = Vector3.one * stats[weaponLevel].range;

        spawnWaitTime = stats[weaponLevel].timeBetweenSpawn;

        enmeyDamage.damageAmount = stats[weaponLevel].damage;

        enmeyDamage.lifetime = stats[weaponLevel].duration;

        spawnCountDown = 0;

    }

    private void Update()
    {
        spawnCountDown -= Time.deltaTime;
        if (spawnCountDown <= 0)
        {
            spawnCountDown = spawnWaitTime;

            Instantiate(enmeyDamage, enmeyDamage.transform.position, Quaternion.identity, transform).gameObject.SetActive(true);
        }

        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }
    }

}
