using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
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
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        PlayerPrefs.SetFloat("currentScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //if (resetTime)
       // {
       //     
       // }
        float time = gameTime - Time.timeSinceLevelLoad;
       

        if( time <= 0)
        {
            stopTimer = true;
            music.Stop();
            FinalCutscene();
        }

        if (stopTimer == false)
        {
            timerSlider.value = time;
        }
    }
    void FinalCutscene()
    {
        PlayerPrefs.SetFloat("currentScore", Mathf.Round(scoreManager.distanceCount));
        levelLoader.LoadNextLevel();
    }

    public void ResetSlider()
    {
        timerSlider.value = timerSlider.maxValue;
        resetTime = true;
    }
}
