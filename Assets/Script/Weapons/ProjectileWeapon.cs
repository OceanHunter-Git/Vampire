using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public EnemyDamage damager;
    public Projectile projectile;

    private float shotWaitTime;
    private float shotCounter;

    public float weaponRange;
    public LayerMask whatIsEnemy;
    // Start is called before the first frame update
    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            shotCounter = shotWaitTime;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, weaponRange * stats[weaponLevel].range, whatIsEnemy);
            if (enemies.Length > 0)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;

                    Vector3 direction = targetPosition - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    Instantiate(projectile, projectile.transform.position, projectile.transform.rotation).gameObject.SetActive(true);
                }
                SFXManager.instance.PlaySFX(6);
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

        shotWaitTime = stats[weaponLevel].timeBetweenSpawn;

        shotCounter = 0;

        projectile.moveSpeed = stats[weaponLevel].speed;
    }
}
