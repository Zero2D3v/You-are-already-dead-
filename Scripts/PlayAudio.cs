using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script in charge of monster snail side of intro cutscene audio
public class PlayAudio : MonoBehaviour
{
    public AudioSource sauce;
    public AudioSource sceneSource;
    public AudioClip snailMonsta;
    public AudioClip snailRustle;
    public AudioClip thunder;
    public GameObject flash;

    public void Start()
    {
        flash.SetActive(false);
    }
    public void PlaySound()
    {
        sauce.PlayOneShot(snailMonsta, 5f);
    }

    public void PlayRustle()
    {
        sauce.PlayOneShot(snailRustle, 0.2f);
    }
    public void PlayThunder()
    {
        flash.SetActive(true);
        sceneSource.PlayOneShot(thunder);
    }
}
