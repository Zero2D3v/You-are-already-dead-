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

    //public bool newHighscore;

    public float distanceCount;
    public float hiScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool nos;

    public bool doublePoints;
        

    // Start is called before the first frame update
    void Start()
    {
        nos = false;
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
            
        }
        //PlayerPrefs.SetFloat("HighScore", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            distanceCount += pointsPerSecond * Time.deltaTime;
            
        }

        if(distanceCount > hiScoreCount)
        {
            hiScoreCount = distanceCount;
            PlayerPrefs.SetFloat("HighScore", Mathf.Round(hiScoreCount));
            //newHighscore = true;
        }

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

    public void EnableNOS()
    {
        nos = true;
        pointsPerSecond *= 2f;
    }
    public void DisableNOS()
    {
        nos = false;
        pointsPerSecond *= 0.5f;
    }

    public void IncreaseScore(float amount)
    {
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
