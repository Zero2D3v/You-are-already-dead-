using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//randomly spawns any tof the 3 power ups at any point on the screen offset infront of the player
public class RandomSpawner : MonoBehaviour
{
    public GameObject[] pickUps;
    public float spawnInterval;
    private float spawnTimer;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, -10, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            RadSpawn();
            ResetSpawnTimer();
        }
    }

    void ResetSpawnTimer()
    {
        spawnTimer = spawnInterval;
    }

    void RadSpawn()
    {
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width) -2f, Random.Range(0, Screen.height) -10f, Camera.main.farClipPlane / 2));

        Instantiate(pickUps[Random.Range(0, pickUps.Length)], screenPosition + offset, Quaternion.identity);
    }
}
