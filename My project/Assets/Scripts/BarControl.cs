using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarControl : MonoBehaviour
{
    
    public Image fillBar;
    public ScoreManager scoreManager;
    private bool doublePoints;
    
    //updates bar UI
    public void UpdateBar(float amount)
    {
        //checks if double points is set to true in score manager
        doublePoints = scoreManager.doublePoints;
        Debug.Log("x2 points" + doublePoints);

        //if bar is not full and doublepoints is not active, then increase the bar fill by the unmodified amount
        if (fillBar.fillAmount != 1 && !doublePoints)
        {
            fillBar.fillAmount += amount;
            Debug.Log(amount);
        }
        //if doublepoints is true and bar not full, then double the amount before adding to bar fill
        else if (fillBar.fillAmount != 1 && doublePoints)
        {
            amount *= 2;
            fillBar.fillAmount += amount;
            Debug.Log(amount);
        }
        //if bar is already full but double points is false, then increase the score by the amount (x500 as amount is the percentage of bar fill so either 0.1f or 0.2f)
        else if (fillBar.fillAmount >= 1 && !doublePoints)
        {
            scoreManager.IncreaseScore(amount * 500f);
        }
        //and if bar already full and doublepoints true then then increase score by twice the amount as before using the IncreseScore() function in ScoreManager script
        else if(fillBar.fillAmount >= 1 && doublePoints)
        {
            scoreManager.IncreaseScore(amount * 1000f);
        }
    }
}
