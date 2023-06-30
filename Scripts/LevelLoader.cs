using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

//script for handling scene changes as well as menu button functions
public class LevelLoader : MonoBehaviour
{
    public float introTime = 8f;
    public Animator transition;

     public void SnailCutscene()
    {
        transition.SetBool("cutscene1", true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
}
