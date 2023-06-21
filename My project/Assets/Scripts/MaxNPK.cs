using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxNPK : MonoBehaviour
{
    public GameObject NPK;

    private void OnEnable()
    {
        NPK.SetActive(true);
    }
}
