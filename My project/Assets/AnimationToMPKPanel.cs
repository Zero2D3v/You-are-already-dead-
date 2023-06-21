using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToMPKPanel : MonoBehaviour
{
    public ScoreManager scoreManager;
    public void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void DisableNPK()
    {
        Invoke("NPKBonus", 0.1f);
        gameObject.SetActive(false);
    }

    public void NPKBonus()
    {
        scoreManager.IncreaseScore(2000f);
    }
}
