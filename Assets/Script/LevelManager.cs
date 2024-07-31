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

    public float waitToShowEndScreen;
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

        StartCoroutine(EndLevelCo());
    }

    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToShowEndScreen);

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        UIController.instance.endTimeText.text = minutes.ToString() + "mins" + seconds.ToString("00") + "secs";
        UIController.instance.levelEndScreen.gameObject.SetActive(true);

    }
}
