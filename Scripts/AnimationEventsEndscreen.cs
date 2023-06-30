using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationEventsEndscreen : MonoBehaviour
{
    
    public TextMeshProUGUI text;

    public void SetNewHighscoreText()
    {
        text.text = "NEW HIGHSCORE!";
    }

    
}
