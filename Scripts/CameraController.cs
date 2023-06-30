using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    private float size;


    // Start is called before the first frame update
    void Start()
    {
        size = bg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera
     // Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
     //
     // transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);

        //background
        if(transform.position.y >= bg2.position.y)
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBG();
        }

        if (transform.position.y < bg1.position.y)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBG();
        }
    }

    private void LateUpdate()
    {
        //Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y - 2f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, 1f);
    }

    private void SwitchBG()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
