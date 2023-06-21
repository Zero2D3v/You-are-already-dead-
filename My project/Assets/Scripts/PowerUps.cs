using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private GameObject thisObject;
    public GameObject floatingText;
   public string text;

    private void Start()
    {
        thisObject = this.gameObject;
    }
    private void OnDestroy()
    {
        Instantiate(floatingText, transform);
    }
}
