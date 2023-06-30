using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for handling cutscene sequence  and loading next level from animation events
public class AnimationEventToCutscene : MonoBehaviour
{
    public LevelLoader lvlLoader;
    public EndingManager endingManager;

    // Start is called before the first frame update
    void SnailCutscene()
    {
        //used on multiple game objects so checks for level loader component don't want all game objects to be able to change the scene!
        if (lvlLoader)
        {
            lvlLoader.SnailCutscene();
        }
        
    }
    void LoadNextLevel()
    {
        if (lvlLoader)
        {
            lvlLoader.LoadNextLevel();
        }
    }
    void CheckScore()
    {
        if (endingManager)
        {
            endingManager.CheckScore();
        }
    }
    //for stopping the advancing monster snail ending cutscene if the player wins
    void BreakAnimation()
    {
       //stops the snail just as it's about to eat the player to be replaced with two sprite game objects pre split in half to work in unison with sword slash screen flash and player animation in developement if player win.
            endingManager.snailLose.BreakAnimation();
    }
}
