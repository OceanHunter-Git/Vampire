using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    public float rotateSpeed;
    public float throwPower;
    public Rigidbody2D theRb;
    // Start is called before the first frame update
    void Start()
    {
        theRb.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(theRb.velocity.x));
    }
}
