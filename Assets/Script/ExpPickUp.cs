using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ExpPickUp : MonoBehaviour
{
    public int expValue;
    private PlayerController Player;

    private bool isMoveToPlayer = false;

    public float moveSpeed;
    public float expCheckTime;
    private float expCheckCounter;
    // Start is called before the first frame update
    void Start()
    {
        Player = PlayerHealthController.instance.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
        }    
        else
        {
            expCheckCounter -= Time.deltaTime;
            
            if (expCheckCounter <= 0)
            {
                expCheckCounter = expCheckTime;

                if (Vector3.Distance(transform.position, Player.transform.position) < Player.pickUpRange)
                {
                    isMoveToPlayer = true;
                    moveSpeed += Player.moveSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ExperienceLevelSystem.instance.GetExp(expValue);
            Destroy(gameObject);
        }
    }
}
