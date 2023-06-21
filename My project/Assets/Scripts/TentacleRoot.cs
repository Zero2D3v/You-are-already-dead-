using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleRoot : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] SegmentPoses;
    private Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    public Transform[] offRoots;

    private void Start()
    {
        lineRend.positionCount = length;
        SegmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        SegmentPoses[0] = targetDir.position;

        for (int i = 1; i < SegmentPoses.Length; i++)
        {
            SegmentPoses[i] = Vector3.SmoothDamp(SegmentPoses[i], SegmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i/trailSpeed);

            //offRoots[i - 1].transform.position = SegmentPoses[i];
        }
        lineRend.SetPositions(SegmentPoses);
    }
}
