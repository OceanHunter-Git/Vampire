using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelSystem : MonoBehaviour
{
    public static ExperienceLevelSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentExperience;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExp(int experienceToGet)
    {
        currentExperience += experienceToGet;
    }
}
