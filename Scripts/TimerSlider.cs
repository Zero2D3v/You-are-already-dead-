using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script handles the animated UI timer slider in bottom right of screen and loads the end game scene when time runs out
public class TimerSlider : MonoBehaviour
{
    //declare fields
    public LevelLoader levelLoader;
    public ScoreManager scoreManager;
    public AudioSource music;

    public Slider timerSlider;
    public float gameTime = 45f;

    private bool stopTimer;
    private bool resetTime;

    // Start is called before the first frame update
    void Start()
    {
        //set references and starting values
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        PlayerPrefs.SetFloat("currentScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //count time since level load
        float time = gameTime - Time.timeSinceLevelLoad;
        //when game time runs out, stop timer and sounds before loading end game scene
        if( time <= 0)
        {
            stopTimer = true;
            music.Stop();
            FinalCutscene();
        }
        //if timer still going then update UI slider position to match
        if (stopTimer == false)
        {
            timerSlider.value = time;
        }
    }
    //stores player score in PlayerPrefs before loading next scene so value still accessible and can be uses to determine win lose sequence.
    void FinalCutscene()
    {
        PlayerPrefs.SetFloat("currentScore", Mathf.Round(scoreManager.distanceCount));
        levelLoader.LoadNextLevel();
    }
    //function used to troubleshoot when was not working properly
    public void ResetSlider()
    {
        timerSlider.value = timerSlider.maxValue;
        resetTime = true;
    }
}
