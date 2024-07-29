using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int coinValue;
    private PlayerController Player;

    private bool isMoveToPlayer = false;

    public float moveSpeed;
    public float coinCheckTime;
    private float coinCheckCounter;
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
            coinCheckCounter -= Time.deltaTime;

            if (coinCheckCounter <= 0)
            {
                coinCheckCounter = coinCheckTime;

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
            CoinController.instance.GetCoin(coinValue);
            Destroy(gameObject);
        }
    }
}
