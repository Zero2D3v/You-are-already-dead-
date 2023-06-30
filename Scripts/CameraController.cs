using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script handles infinite scrolling background using two seamless repaeted textures
public class CameraController : MonoBehaviour
{
    //declare fields
    public Transform target;

    public Transform bg1;

    public Transform bg2;

    private float size;


    // Start is called before the first frame update
    void Start()
    {
        //get size of texture 1
        size = bg1.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if texture 1 position is lower than texture 2 position
        if(transform.position.y >= bg2.position.y)
        {
            //put texture 1 underneath texture 2 so it appears endless
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            //switch how they're labelled to match switching back and forth as continue down following camera
            SwitchBG();
        }
        //same but for the other texture
        if (transform.position.y < bg1.position.y)
        {
            bg2.position = new Vector3(bg2.position.x, bg1.position.y - size, bg2.position.z);
            SwitchBG();
        }
    }
    //late update so other calculations already done to avoid jitter
    private void LateUpdate()
    {
        //calculates new target position for camera and interpolates with an offset using lerp to ensure smooth movement
        Vector3 targetPos = new Vector3(transform.position.x, target.position.y - 2f, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, 1f);
    }
    //switches how backgrounds are called
    private void SwitchBG()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
