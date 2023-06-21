using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            snailAnim.SetBool("playerWin", true);
            snailHalves.SetActive(true);
            monsterOriginal.SetActive(false);
            endingManager.WinDecapitate();
            Invoke("Slice", 3.5f);
        }
        else return;
        
    }
    void Slice()
    {
        //endingManager.CheckScore();
        endingManager.EnableFlash();
        endingManager.audioSource.PlayOneShot(endingManager.yadCut, 0.3f);
        snailTopAnim.SetBool("slice", true);
    }
}
