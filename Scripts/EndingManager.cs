using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

//script handles recorded values from previous scene, analysis of those values then which events happen because of them. Also has functions called by other scripts and is a central hub of script communication hence the manager name.
public class EndingManager : MonoBehaviour
{
    //declare fields
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

    public GameObject flash;

    public GameObject currentScore;

    public TextMeshProUGUI winLoseText;
    public TextMeshProUGUI currentScoreText;

    public int newHighScoreValue;
    public bool newHighscore;
    public float score;
    public float target;
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        //gets the score from previous scene
        currentScoreText.text = PlayerPrefs.GetFloat("currentScore").ToString();
        //checks if new highscore
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
        //makes sure ending UI elements are set to off
        flash.SetActive(false);
        endScreen.SetActive(false);
        leaderBoard.SetActive(false);
    }
    //in charge of enabling game object with various onEnable animations and scripts that modify flash object depending on win/loss/score and then animation events call functions accordingly
    public void EnableFlash()
    {
        flash.SetActive(true);
    }
    //checks result
    void CheckResult()
    {
        if (score >= target)
        {
            win = true;
        }
        else
        {
            win = false;
            EnableFlash();
        }
        //calls update text function after result checked
        UpdateWinLose();
    }
    //set text on end screen
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
    //win cutscene direction including my notes pre implementation
    public void WinDecapitate()
    {
        //my notes on how I wanted the cutscene to play out pre-implementation, room for animations in development
        //grow
        //samurai pose
        //darken screen time freeze
        audioSource.PlayOneShot(youAreAlreadyDead);
        //eye glint
        //time slice with sound and enable flash
        //snail monster in half
        //win screen
    }
    //gets score from previous scene and calls CheckResult() function. Called by animation event
    public void CheckScore()
    {
        score = PlayerPrefs.GetFloat("currentScore");
        CheckResult();
            Debug.Log(score);
    }
    //in charge of playing new highscore pulse anim
    public void PlayNewHighScoreAnim()
    {
        newHighscoreAnim.SetBool("newHighscore", true);
    }
    //enables highscore table and disables interfrerring text underneath for clean screen
    public void EnableLeaderBoard()
    {
        endScreenText.SetActive(false);
        leaderBoard.SetActive(true);
    }
    //enables leaderboard on animation event and plays animation dependent on result in allocated time
    public void InvokeHighScoreANimLeaderboard()
    {
        if (newHighscore)
        {
            Invoke("PlayNewHighScoreAnim", 1f);
        }

        Invoke("EnableLeaderBoard", 3f);
    }

    
}
