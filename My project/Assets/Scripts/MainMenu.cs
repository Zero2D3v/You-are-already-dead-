using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;

   public void PlayGame()
    {
        SceneManager.LoadScene("Intro");
    }

    //commented out for webGL build
   //public void QuitGame()
   //{
   //    Application.Quit();
   //}
}
