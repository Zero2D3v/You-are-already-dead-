using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script incharge of the player win cutscene
public class SnailLose : MonoBehaviour
{
    public Animator snailAnim;
    public Animator snailTopAnim;
    //public Animator snailBottomAnim;
    public GameObject snailHalves;
    public GameObject monsterOriginal;

    public EndingManager endingManager;

    private void Start()
    {
        snailHalves.SetActive(false);
    }
    public void BreakAnimation()
    {
        endingManager.CheckScore();

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
    void Slice()
    {
        endingManager.EnableFlash();
        endingManager.audioSource.PlayOneShot(endingManager.yadCut, 0.3f);
        snailTopAnim.SetBool("slice", true);
    }
}
