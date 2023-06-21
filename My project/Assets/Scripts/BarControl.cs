using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    
    public Image fillBar;
    public ScoreManager scoreManager;
    private bool doublePoints;
    

    public void UpdateBar(float amount)
    {
        doublePoints = scoreManager.doublePoints;
        Debug.Log("x2 points" + doublePoints);

        if (fillBar.fillAmount != 1 && !doublePoints)
        {
            fillBar.fillAmount += amount;
            Debug.Log(amount);
        }
        else if (fillBar.fillAmount != 1 && doublePoints)
        {
            amount *= 2;
            fillBar.fillAmount += amount;
            Debug.Log(amount);
        }
        else if (fillBar.fillAmount >= 1 && !doublePoints)
        {
            scoreManager.IncreaseScore(amount * 500f);
        }
        else if(fillBar.fillAmount >= 1 && doublePoints)
        {
            scoreManager.IncreaseScore(amount * 1000f);
        }
    }
}
