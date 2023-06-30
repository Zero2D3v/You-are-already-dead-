using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script incharge of the player win cutscene
public class SnailLose : MonoBehaviour
{
    public Animator snailAnim;
    public Animator snailTopAnim;
    //public Animator snailBottomAnim; - didn't need as only top half of snail monster needs to move on slice
    public GameObject snailHalves;
    public GameObject monsterOriginal;

    public EndingManager endingManager;

    private void Start()
    {
        snailHalves.SetActive(false);
    }
    //called by animation event on other script, if win then stops player being eaten and replaces snail with pre cut in 2 snail game objects with different animations
    public void BreakAnimation()
    {
        endingManager.CheckScore();
        //checks fetched result
        if (endingManager.win)
        {
            //sets player win animation bool to true
            snailAnim.SetBool("playerWin", true);
            //replaces snail sprite with two pre sliced sprites in smae position with diferent animator
            snailHalves.SetActive(true);
            monsterOriginal.SetActive(false);
            //calls win decapitate function on ending manager
            endingManager.WinDecapitate();
            //calls slice function and animation after sound has finished playing at corect time
            Invoke("Slice", 3.5f);
        }
        else return;
    }
    //handles win slice snail monster part of cutscene, called to match timings of other animtions and sounds on animation event
    void Slice()
    {
        endingManager.EnableFlash();
        endingManager.audioSource.PlayOneShot(endingManager.yadCut, 0.3f);
        snailTopAnim.SetBool("slice", true);
    }
}
