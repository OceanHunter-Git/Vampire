using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : Weapon
{
    public EnemyDamage enmeyDamage;
    public Transform holder , fireballToSpawn;
    public float rotationSpeed;
    private float spawnWaitTime;
    private float spawnCountDown;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    void SetStats()
    {


        transform.localScale = Vector3.one * stats[weaponLevel].range;

        spawnWaitTime = stats[weaponLevel].timeBetweenSpawn;

        enmeyDamage.damageAmount = stats[weaponLevel].damage;

        enmeyDamage.lifetime = stats[weaponLevel].duration;

        spawnCountDown = 0;

    }
    // Update is called once per frame
    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime * stats[weaponLevel].speed);
        spawnCountDown -= Time.deltaTime;

        if (spawnCountDown < 0)
        {
            spawnCountDown = spawnWaitTime;

            for (int i = 0; i < stats[weaponLevel].amount; i++)
            {
                float rot = (360 / stats[weaponLevel].amount) * i;
                Instantiate(fireballToSpawn, fireballToSpawn.position, Quaternion.Euler(0f, 0f, rot), holder).gameObject.SetActive(true);
                SFXManager.instance.PlaySFX(8);
            }
            
        }
        if (statsUpdated)
        {
            statsUpdated = false;
            SetStats();
        }
    }
}
