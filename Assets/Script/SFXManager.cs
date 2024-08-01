using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    private void Awake()
    {
        instance = this;
    }

    public AudioSource[] soundEffects;
    // Start is called before the first frame update
    public void PlaySFX(int sfxToPlay)
    {
        soundEffects[sfxToPlay].Stop();
        soundEffects[sfxToPlay].Play();
    }

    public void PlaySFXPictched(int sfxToPlay)
    {
        soundEffects[sfxToPlay].pitch = Random.Range(0.8f, 1.2f);
        PlaySFX(sfxToPlay);
    }
}
