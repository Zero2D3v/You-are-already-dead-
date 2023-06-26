using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        if (endingManager.win)
        {
            flashImage.color = Color.white;
        }
        else
        {
            endScreenImage.color = Color.red;
            endingManager.audioSource.PlayOneShot(endingManager.blooSplatter, 0.5f);
            bloodDrip.SetActive(true);
        }
            
    }

    public void EatPLayer()
    {
        if (!endingManager.win)
        {
            Destroy(endingManager.player);

            playerEaten = true;

        }

    }
    public void FatalitySound()
    {
        if (playerEaten)
        {
            endingManager.audioSource.PlayOneShot(endingManager.fatality, 5f);

        }
    }

    public void EnableEndScreen()
    {
        if (endingManager.win)
        {
            endScreenImage.color = new Color(0f, 1f, 0f, 0.3f);
            endScreen.SetActive(true);
        }
        else if (!endingManager.win)
        {
            endScreenImage.color = new Color(1f, 0f, 0f, 0.3f);
            endScreen.SetActive(true);
        }

        
    }

    public void NewHighScoreLeaderboard()
    {
        endingManager.InvokeHighScoreANimLeaderboard();
    }
}
