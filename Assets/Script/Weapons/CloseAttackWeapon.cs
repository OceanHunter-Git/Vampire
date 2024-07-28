using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamage damager;

    private float attackWaitTime;
    private float attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0)
        {
            attackCounter = attackWaitTime;
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    damager.transform.rotation = Quaternion.identity;
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
                
            }
            Instantiate(damager, damager.transform.position, damager.transform.rotation, transform).gameObject.SetActive(true);

            for (int i = 1; i < stats[weaponLevel].amount; i++)
            {
                float rot = (360 / stats[weaponLevel].amount) * i;
                Instantiate(damager, damager.transform.position, Quaternion.Euler(0f,0f,damager.transform.rotation.eulerAngles.z + rot), transform).gameObject.SetActive(true);
            }
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

        attackWaitTime = stats[weaponLevel].timeBetweenSpawn;

        attackCounter = 0;
    }
}
