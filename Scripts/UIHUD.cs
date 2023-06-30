using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script changed to just simple bar control, attacjhed to each UI bar game object, called by other scripts
public class UIHUD : MonoBehaviour
{
    public Image fill;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //increases the bar fill amount with pick ups of each nutrient
    public void UpdateBar(float fraction)
    {
        fill.fillAmount = fraction;
    }
}
