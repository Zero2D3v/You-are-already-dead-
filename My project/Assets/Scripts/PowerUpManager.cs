using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//using UnityEditor.Rendering;
using UnityEngine;

using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{

    public GameObject maxNPKPanel;
    public AudioSource audioSource;
    public AudioClip maxNPKAchieved;

    public GameObject[] powerUpLocations;
    public GameObject doublePoints;
    public GameObject boostIcon;

    public Image bananaBar;
    public Image tunaBar;
    public Image no2Bar;

    private int count;

    float bBarValue;
    float tBarValue;
    float nBarValue;

    bool bBarFull;
    bool tBarFull;
    bool nBarFull;

    //set references and reset values
    private void Start()
    {
        bBarValue = bananaBar.fillAmount;
        tBarValue = tunaBar.fillAmount;
        nBarValue = no2Bar.fillAmount;

        bBarFull = false;
        tBarFull = false;
        nBarFull = false;

        count = 0;

        maxNPKPanel.SetActive(false);
        boostIcon.SetActive(false);
        doublePoints.SetActive(false);
    }
    //check if UI bar full
    public void Update()
    {
        CheckAmounts();

        if(bBarValue >= 1f)
        {
            bBarFull = true;
        }
        if(tBarValue >= 1f)
        {
            tBarFull = true;
        }
        if(nBarValue >= 1f)
        {
            nBarFull = true;
        }
    }
    //check UI bar amounts as they update
    void CheckAmounts()
    {
        bBarValue = bananaBar.fillAmount;
        tBarValue = tunaBar.fillAmount;
        nBarValue = no2Bar.fillAmount;
        //if all bars full then enable the time freeze event and UI and score bonus
        if(bBarFull && tBarFull && nBarFull)
        {
            MaxNPK();
        }
    }
    void MaxNPK()
    {
        if (!maxNPKPanel.activeSelf)
        {
            maxNPKPanel.SetActive(true);
            audioSource.PlayOneShot(maxNPKAchieved, 5f);
        }
        else
        {
            return;
        }
    }

    public void EnablePowerUpUI(GameObject powerUpUI)
    {
        if (powerUpUI.activeSelf == false)
        {
            powerUpUI.SetActive(true);
        }
    }
    public void DisablePowerUpUI(GameObject powerUpUI)
    {
        powerUpUI.SetActive(false);
    }
}
