using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public PlayerRotateToTarget player;

    public Animator scoreAnim;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI hiScoreText;

    public float distanceCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool nos;

    public bool doublePoints;
        

    // Start is called before the first frame update
    void Start()
    {
        //make sure pick up buffs are set to off
        doublePoints = false;
        nos = false;
        //fetch highscore
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //increase score if bool set to true so player going down
        if (scoreIncreasing)
        {
            distanceCount += pointsPerSecond * Time.deltaTime;
            
        }
        //record score as new highscore if previous highscore surpassed
        if(distanceCount > hiScoreCount)
        {
            hiScoreCount = distanceCount;
            PlayerPrefs.SetFloat("HighScore", Mathf.Round(hiScoreCount));
        }
        //update score and highscore values
        distanceText.text = "Score: " + Mathf.Round(distanceCount);
        hiScoreText.text = "High Score: " + Mathf.Round(hiScoreCount);
    }

    public void DisableScoreIncrease()
    {
        scoreIncreasing = false;
    }

    public void EnableScoreIncrease()
    {
        scoreIncreasing = true;
    }
    //doubles points as score meant to represent how far you travelled
    public void EnableNOS()
    {
        nos = true;
        pointsPerSecond *= 2f;
    }
    //resets points back to normal so halves the doubled value
    public void DisableNOS()
    {
        nos = false;
        pointsPerSecond *= 0.5f;
    }

    public void IncreaseScore(float amount)
    {
        //plays a pulse animation on your score to let player know that it increased
        StartAnimation();

        if (!doublePoints)
        {
            distanceCount += amount;
            WorkOutAmountToPrint(amount);

        }
        if (doublePoints)
        {
            amount *= 2;
            distanceCount += amount;
            WorkOutAmountToPrint(amount);

        }
        
    }
    public void WorkOutAmountToPrint(float amount)
    {
        Debug.Log(amount);
        player.textPopupText = ("+")+ amount.ToString();
    }

    public void StartAnimation()
    {
        scoreAnim.SetTrigger("play");
    }
}
