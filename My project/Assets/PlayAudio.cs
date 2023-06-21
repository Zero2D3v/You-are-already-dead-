using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource sauce;
    public AudioClip snailMonsta;
    public void PlaySound()
    {
        sauce.PlayOneShot(snailMonsta, 5f);
    }

}
