using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//script handles New Highscore animation called by animation event if new highscore bool is true
public class AnimationEventsEndscreen : MonoBehaviour
{
    
    public TextMeshProUGUI text;

    public void SetNewHighscoreText()
    {
        text.text = "NEW HIGHSCORE!";
    }

    
}
