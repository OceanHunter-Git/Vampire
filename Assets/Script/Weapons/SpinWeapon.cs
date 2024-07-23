using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public Transform holder , fireballToSpawn;
    public float rotationSpeed;
    public float spawnWaitTime;
    private float spawnCountDown;
    // Start is called before the first frame update
    void Start()
    {
        spawnCountDown = spawnWaitTime;    
    }

    // Update is called once per frame
    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + rotationSpeed * Time.deltaTime);
        spawnCountDown -= Time.deltaTime;

        if (spawnCountDown < 0)
        {
            spawnCountDown = spawnWaitTime;

            Instantiate(fireballToSpawn, fireballToSpawn.position, fireballToSpawn.rotation, holder).gameObject.SetActive(true);
        }
    }
}
