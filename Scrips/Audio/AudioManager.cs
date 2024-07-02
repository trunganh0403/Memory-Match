using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : GameMonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get => instance; }
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip backgroundMusic;
    //[SerializeField] protected AudioClip winSound;
    [SerializeField] protected AudioClip loseSound;
    [SerializeField] protected AudioClip correctAnswerSound;
    [SerializeField] protected AudioClip wrongAnswerSound;
    [SerializeField] protected AudioClip timeUpSound;

    protected override void Awake()
    {
        if (AudioManager.instance != null) Debug.LogError("Only 1 AudioManager allow to exist");
        AudioManager.instance = this;
    }

    protected override void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    //public void PlayWinSound()
    //{
    //    audioSource.PlayOneShot(winSound);
    //}

    public void PlayLoseSound()
    {
        audioSource.PlayOneShot(loseSound);
    }
    public void PlayCorrectAnswerSound()
    {
        audioSource.PlayOneShot(correctAnswerSound);
    }

    public void PlayWrongAnswerSound()
    {
        audioSource.PlayOneShot(wrongAnswerSound);
    }  

    public void PlayTimeUpSound()
    {
        audioSource.PlayOneShot(timeUpSound);
    }
}
