using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    public AudioSource audiosource;
    public AudioClip Death, GameOver, Land, Star;

    void Awake()
    {
        instance = this;
    }

    public void PlayDeath()
    {
        audiosource.clip = Death;
        audiosource.Play();
    }
    public void PlayGameOver()
    {
        audiosource.clip = GameOver;
        audiosource.Play();
    }
    public void PlayLand()
    {
        audiosource.clip = Land;
        audiosource.Play();
    }
    public void PlayStar()
    {
        audiosource.clip = Star;
        audiosource.Play();
    }

}
