using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shakeControl;
    public IEnumerator cameraShakes(float duration, float mag)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * mag;
            float y = Random.Range(-1f, 1f) * mag;

            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }

    public void ShakeCamera()
    {
        if (shakeControl == false)
        {
            StartCoroutine(cameraShakes(0.22f, 0.4f));
            shakeControl = true;
        }
    }
}
