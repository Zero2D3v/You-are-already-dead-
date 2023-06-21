using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public PowerUpManager powerUpManager;

    public IEnumerator Shake (float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        //float elapsed = 0.0f;

        while (powerUpManager.boostIcon.activeSelf)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            //elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
