using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enables UI panel on animation event if all bars filled up
public class MaxNPK : MonoBehaviour
{
    public GameObject NPK;

    private void OnEnable()
    {
        NPK.SetActive(true);
    }
}
