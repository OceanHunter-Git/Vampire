using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private bool gameActive;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        gameActive = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            timer += Time.deltaTime;
            UIController.instance.UpdateTime(timer);
        }    
    }

    public void EndLevel()
    {
        gameActive = false;
    }
}
