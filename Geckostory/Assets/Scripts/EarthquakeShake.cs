using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class EarthquakeShake : MonoBehaviour
{
    public GameObject objectToShake;
    public float shakeDuration = 5.0f;
    public float shakeIntensity = 0.2f;
    public float decreaseFactor = 1.0f;

    private Vector3 originalPosition;
    private bool isShaking = false;

    void Start()
    {
        if (objectToShake == null)
        {
            Debug.LogError("Please assign the objectToShake in the Inspector.");
            enabled = false;
            return;
        }

        originalPosition = objectToShake.transform.position;
    }

    public void StartEarthquakeShake()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }

    IEnumerator ShakeCoroutine()
    {
        isShaking = true;
        float currentShakeDuration = shakeDuration;

        while (currentShakeDuration > 0)
        {
            float shakeX = Random.Range(-shakeIntensity, shakeIntensity);
            float shakeY = Random.Range(-shakeIntensity, shakeIntensity);
            float shakeZ = Random.Range(-shakeIntensity, shakeIntensity);

            Vector3 newPosition = originalPosition + new Vector3(shakeX, shakeY, shakeZ);
            objectToShake.transform.position = newPosition;

            currentShakeDuration -= Time.deltaTime;
            yield return null;
        }

        objectToShake.transform.position = originalPosition;
        isShaking = false;
    }
}