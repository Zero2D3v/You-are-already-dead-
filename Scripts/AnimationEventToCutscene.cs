using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventToCutscene : MonoBehaviour
{
    public LevelLoader lvlLoader;
    public EndingManager endingManager;

    // Start is called before the first frame update
    void SnailCutscene()
    {
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
    void BreakAnimation()
    {
       // if (endingManager.win)
       // {
            endingManager.snailLose.BreakAnimation();
           // endingManager.WinDecapitate();
       // }
        //to do with enable flash/check score anim event
    }
}
