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
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        target = PlayerHealthController.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.velocity = (target.position - transform.position).normalized * moveSpeed;    
        if (hitCountdown > 0)
        {
            hitCountdown -= Time.deltaTime;
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
}
