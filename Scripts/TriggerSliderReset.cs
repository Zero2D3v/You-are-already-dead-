using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script no longer used, was an iteration trying to solve why timer slider would appear to start halfway through after scene change but figured it out and just started on scene change instead of normal start function
public class TriggerSliderReset : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public TimerSlider timerSiderUI;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") ;
        {
            timerSiderUI.ResetSlider();
        }
    }
}
