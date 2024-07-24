using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public TMP_Text damageText;
    public float lifetime;
    private float lifetimeCounter;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetimeCounter > 0)
        {
            lifetimeCounter -= Time.deltaTime;
            if (lifetimeCounter <= 0)
            {
                Destroy(gameObject);
            }
        }
            
    }
    public void setUp(int damageDisplay)
    {
        lifetimeCounter = lifetime;

        damageText.text = damageDisplay.ToString();
    }
}
