using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
