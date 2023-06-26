using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventToSoundIntro : MonoBehaviour
{
    public AudioSource saplingSound;
    public AudioClip grow;
    public AudioClip pop;

    public AudioSource sceneSound;
    public AudioClip sunshine;
    public AudioClip scaryForest;
    public AudioClip thunderSound;

    // Start is called before the first frame update
    void Start()
    {
        sceneSound.PlayOneShot(sunshine);
    }

    public void PlayGrow()
    {
        saplingSound.PlayOneShot(grow);
    }
    public void PlayPop()
    {
        saplingSound.Stop();
        saplingSound.PlayOneShot(pop);
    }
    public void PlayThunder()
    {
        sceneSound.Stop();
        sceneSound.PlayOneShot(thunderSound);
    }
    public void PlayScaryForest()
    {
        
        sceneSound.PlayOneShot(scaryForest);
    }
}
