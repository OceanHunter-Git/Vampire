using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public GameObject deathEffect;
    private void Awake()
    {
        instance = this;
    }
    public Slider healthSlider;
    public float currentHealth, maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PlayerStatsController.instance.health[0].value;
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            LevelManager.instance.EndLevel();
            SFXManager.instance.PlaySFX(3);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
        healthSlider.value = currentHealth;
    }
}
