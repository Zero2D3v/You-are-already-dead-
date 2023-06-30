using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//handles events called by menu buttons
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
