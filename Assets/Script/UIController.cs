using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider expSlider;
    public TMP_Text expText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateExp(int currentExp, int levelExp, int level)
    {
        expSlider.maxValue = levelExp;
        expSlider.value = currentExp;

        expText.text = "Level: " + level.ToString();
    }
}
