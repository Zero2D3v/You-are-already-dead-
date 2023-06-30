using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles animation event time freize event and UI animation of unscaled time
public class AnimationToMPKPanel : MonoBehaviour
{
    //declare field
    public ScoreManager scoreManager;
    //stop time using time scale, called from animation event where animator is set to unscaled time so unnaffected
    public void StopTime()
    {
        Time.timeScale = 0.0f;
    }
    //reset time scale
    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }
    //Nitrogen Phosphorus Pottassium UI panel enabled in a different script, so this one just handles disabling
    public void DisableNPK()
    {
        //increase score delayed so happens after time freeze so player feedback visable as score pulse plays after increase
        Invoke("NPKBonus", 0.1f);
        gameObject.SetActive(false);
    }

    public void NPKBonus()
    {
        //increase score by large bonus reward
        scoreManager.IncreaseScore(2000f);
    }
}
