using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;

    private void Awake()
    {
        instance = this;
    }

    public int coinCounter;

    public CoinPickUp coin;
    public void SpawnCoin(Vector3 Location, int coinValue)
    {
        Instantiate(coin, Location + new Vector3(0.2f, 0.1f, 0f), Quaternion.identity).coinValue = coinValue;
    }
    public void GetCoin(int coinToAdd)
    {
        coinCounter += coinToAdd;
        UIController.instance.UpdateCoin();
        SFXManager.instance.PlaySFX(2);
    }

    public void SpendCoin(int coinToSpend)
    {
        coinCounter -= coinToSpend;
    }
}
