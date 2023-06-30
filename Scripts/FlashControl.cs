using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script in charge of which events happen in end cutscene depending on results of previous scene stored on ending manager script
public class FlashControl : MonoBehaviour
{
    public GameObject bloodDrip;
    public GameObject flash;
    public GameObject endScreen;
    public Image flashImage;
    public Image endScreenImage;
    public EndingManager endingManager;
    public bool playerEaten;

    //script handles the ending cutscens depending on the values of the ending manager script
    private void OnEnable()
    {
        //check result and set flash to white for sword slash on win and red for eaten and blood splatter if lose
        if (endingManager.win)
        {
            flashImage.color = Color.white;
        }
        else
        {
            //set flash panel to red
            endScreenImage.color = Color.red;
            //play blood splatter sound at half noise scale to blance better with other sounds
            endingManager.audioSource.PlayOneShot(endingManager.blooSplatter, 0.5f);
            //enable game object which holds the blood splatter animation to play on enable
            bloodDrip.SetActive(true);
        }
            
    }
    //function called on animation event if lose, timed to fit other animations and sounds
    public void EatPLayer()
    {
        //if lose
        if (!endingManager.win)
        {
            //destroy player game object
            Destroy(endingManager.player);
            //record player eaten
            playerEaten = true;

        }

    }
    //function called by animation event
    public void FatalitySound()
    {
        if (playerEaten)
        {
            //play voice recording I made and edited to sound like the mortal combat lose sound, called after blood splatter sound finished
            endingManager.audioSource.PlayOneShot(endingManager.fatality, 5f);

        }
    }
    //called from animation event after either cutscene finished
    public void EnableEndScreen()
    {
        //if win
        if (endingManager.win)
        {
            //change panel colour to green before set active
            endScreenImage.color = new Color(0f, 1f, 0f, 0.3f);
            endScreen.SetActive(true);
        }
        //if lose
        else if (!endingManager.win)
        {
            //change panel colour to red before set active, both with transparecy
            endScreenImage.color = new Color(1f, 0f, 0f, 0.3f);
            endScreen.SetActive(true);
        }

        
    }
    //calls function on ending manager to do with highscore table invoked after time so all works in sequence with animations
    public void NewHighScoreLeaderboard()
    {
        endingManager.InvokeHighScoreANimLeaderboard();
    }
}
