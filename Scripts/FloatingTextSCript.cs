using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextSCript : MonoBehaviour
{

    public float destroyTime = 2f;
    public Vector3 randomizeIntensity = new Vector3(5f, 5f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += new Vector3(Random.Range(-randomizeIntensity.x, randomizeIntensity.x), Random.Range(-randomizeIntensity.y, randomizeIntensity.y), 0f);
    }

}
