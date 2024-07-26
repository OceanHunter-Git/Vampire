using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerController.instance.transform;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + new Vector3(0,0,-10);    
    }
}
