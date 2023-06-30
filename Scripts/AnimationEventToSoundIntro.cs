using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles sound queues in intro cutscene
public class AnimationEventToSoundIntro : MonoBehaviour
{
    //declare audio sources and clips
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
        //scene starts with ambient sunshine sound as innocent sapling grows out of seed
        sceneSound.PlayOneShot(sunshine);
    }

    public void PlayGrow()
    {
        //plays growth sound
        saplingSound.PlayOneShot(grow);
    }
    public void PlayPop()
    {
        //stops growth sound and plays pop sound to match animation, sunshine sound on different audio source so still playing in background
        saplingSound.Stop();
        saplingSound.PlayOneShot(pop);
    }
    public void PlayThunder()
    {
        //stops sunshine sound and plays thunder clap sound which is accompanied by screen flash to mimic lightning
        sceneSound.Stop();
        sceneSound.PlayOneShot(thunderSound);
    }
    //did have ambient sound change from sunshine to scary forest but animations too short upon playtesting, here for animations in development
    public void PlayScaryForest()
    {
        
        sceneSound.PlayOneShot(scaryForest);
    }
}
