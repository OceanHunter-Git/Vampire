using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowWeapon : Weapon
{
    public EnemyDamage damager;

    private float throwWaitTime;
    private float throwCounter;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        throwCounter -= Time.deltaTime;
        if (throwCounter <= 0)
        {
            throwCounter = throwWaitTime;

            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                Instantiate(damager, damager.transform.position, damager.transform.rotation).gameObject.SetActive(true);
                
            }
            SFXManager.instance.PlaySFX(4);
        }
        
        if (statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }
    }

    void SetStats()
    {
        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        damager.damageAmount = stats[weaponLevel].damage;

        damager.lifetime = stats[weaponLevel].duration;

        throwWaitTime = stats[weaponLevel].timeBetweenSpawn;

        throwCounter = 0;
    }
}
