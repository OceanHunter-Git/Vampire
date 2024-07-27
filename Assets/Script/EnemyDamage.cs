using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float lifetime;
    public float damageAmount;
    public float growthSpeed;
    private Vector3 targetSize;
    public bool isKnockDown;
    public bool destroyParent;
    public bool damageOverTime;
    public float timeBetweenDamage;
    private float damageCountDown;

    private List<EnemyController> enemiesInRange = new List<EnemyController>();
    // Start is called before the first frame update
    void Start()
    {
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, growthSpeed * Time.deltaTime);
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            targetSize = Vector3.zero;
            if (transform.localScale == Vector3.zero)
            {
                Destroy(gameObject);
                if (destroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
        if (damageOverTime == true)
        {
            damageCountDown -= Time.deltaTime;
            if (damageCountDown <= 0)
            {
                damageCountDown = timeBetweenDamage;

                for (int i = 0; i < enemiesInRange.Count; i++)
                {
                    if (enemiesInRange[i] != null)
                    {
                        enemiesInRange[i].TakeDamage(damageAmount,isKnockDown);
                    }
                    else
                    {
                        enemiesInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageOverTime == false)
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().TakeDamage(damageAmount, isKnockDown);
            }
        }
        else
        {
            if (collision.tag == "Enemy")
            {
                enemiesInRange.Add(collision.GetComponent<EnemyController>());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (damageOverTime == true)
        {
            if (collision.tag == "Enemy")
            {
                enemiesInRange.Remove(collision.GetComponent<EnemyController>());
            }
        }
    }
}
