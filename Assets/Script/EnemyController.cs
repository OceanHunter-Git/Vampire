using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D enemyRb;
    public float moveSpeed;
    private Transform target;
    public float damage;
    public float hitWaitTime;
    private float hitCountdown;
    public float health;
    private float knockDownTime = .5f;
    private float knockDownCounter;
    public int expValue;

    public int coinValue;
    public float dropCoinRate;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        target = PlayerHealthController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.gameObject.activeSelf)
        {


            if (knockDownCounter > 0)
            {
                knockDownCounter -= Time.deltaTime;
                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2f;
                }
                if (knockDownCounter <= 0)
                {
                    knockDownCounter = 0;
                    moveSpeed = MathF.Abs(moveSpeed * .5f);
                }
            }
            enemyRb.velocity = (target.position - transform.position).normalized * moveSpeed;
            if (hitCountdown > 0)
            {
                hitCountdown -= Time.deltaTime;
            }
        }
        else
        {
            enemyRb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitCountdown <= 0)
        {
            PlayerHealthController.instance.TakeDamage(damage);
            hitCountdown = hitWaitTime;
        }    
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if (health <= 0)
        {
            Destroy(gameObject);
            ExperienceLevelSystem.instance.SpawnExp(transform.position, expValue);
            SFXManager.instance.PlaySFX(0);

            if (UnityEngine.Random.Range(0f, 1f) < dropCoinRate)
            {
                CoinController.instance.SpawnCoin(transform.position, coinValue);

            }
        }
        else
        {
            SFXManager.instance.PlaySFX(1);
        }
        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
        
        
    }
    public void TakeDamage(float damageToTake, bool isKnockBack)
    {
        TakeDamage(damageToTake);

        if (isKnockBack) {
            knockDownCounter = knockDownTime;
        }
    }
}


