using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EndingManager : MonoBehaviour
{
    //public HighscoreTable leaderboard;
    //public ScoreManager scoreManager;
    public Animator newHighscoreAnim;

    public GameObject leaderBoard;

    public FlashControl flashControl;
    public SnailLose snailLose;

    public AudioSource audioSource;
    public AudioClip youAreAlreadyDead;
    public AudioClip yadCut;
    public AudioClip blooSplatter;
    public AudioClip fatality;

    public GameObject player;
    public Animator playerAnim;
    public GameObject enemy;
    public Animator snailAnimator;

    public GameObject endScreen;
    public GameObject endScreenText;
    //public Image endScreenImage;
    public GameObject flash;
    //public Image flashImage;

    //public GameObject highScore;
    public GameObject currentScore;

    public TextMeshProUGUI winLoseText;
    public TextMeshProUGUI currentScoreText;
    //public TextMeshProUGUI highScoreText;

    public int newHighScoreValue;
    public bool newHighscore;
    public float score;
    public float target;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        //currentScoreText = currentScore.GetComponent<TextMeshProUGUI>();
        //highScoreText = highScore.GetComponent<TextMeshProUGUI>();
        


        currentScoreText.text = PlayerPrefs.GetFloat("currentScore").ToString();
        //highScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
        //PlayerPrefs.SetFloat("HighScore", 0);

        if (PlayerPrefs.GetFloat("currentScore") >= PlayerPrefs.GetFloat("HighScore"))
        {
            newHighScoreValue = (int)(PlayerPrefs.GetFloat("currentScore"));
            newHighscore = true;
        }
        else if((PlayerPrefs.GetFloat("currentScore") < PlayerPrefs.GetFloat("HighScore")))
        {
            newHighScoreValue = (int)(PlayerPrefs.GetFloat("currentScore"));
            newHighscore = false;
        }

        flash.SetActive(false);
        endScreen.SetActive(false);
        leaderBoard.SetActive(false);
        //CheckScore();
       // CheckResult();
       // win = false;

        
        
      // {
      //     snailAnimator.SetBool("alive", win);
      //     //flash red
      //     //player disabled
      //     //snail anim scale towards screen eaten mouth
      //     //animation event flash red
      //     loseScreen.SetActive(true);
      // }
    }

    public void EnableFlash()
    {
        flash.SetActive(true);
    }

    void CheckResult()
    {
        if (score >= target)
        {
            win = true;
            //WinDecapitate();
        }
        else
        {
            win = false;
            EnableFlash();
        }
        
        UpdateWinLose();
    }
    void UpdateWinLose()
    {
        if (win)
        {
            winLoseText.text = "YoU wOn!";

        }
        else if (!win)
        {
            winLoseText.text = "GAME OVER";
        }
    }
    public void WinDecapitate()
    {
        //grow
        //samurai pose
        //darken screen time freeze
        audioSource.PlayOneShot(youAreAlreadyDead);
        //eye glint
        //time slice with sound and enable flash
        //snail monster in half
        //win screen
    }
    public void CheckScore()
    {
        score = PlayerPrefs.GetFloat("currentScore");
        CheckResult();
            Debug.Log(score);
    }

    

    public void PlayNewHighScoreAnim()
    {
        newHighscoreAnim.SetBool("newHighscore", true);
    }

    public void EnableLeaderBoard()
    {
        endScreenText.SetActive(false);
        leaderBoard.SetActive(true);
    }

    public void InvokeHighScoreANimLeaderboard()
    {
        if (newHighscore)
        {
            Invoke("PlayNewHighScoreAnim", 1f);
        }

        Invoke("EnableLeaderBoard", 3f);
    }

    
}
