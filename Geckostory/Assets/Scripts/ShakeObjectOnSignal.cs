using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShakeObjectOnSignal : MonoBehaviour
{
    public GameObject objectToShake;
    public float shakeDuration = 1.0f;
    public float shakeAmount = 0.1f;
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

    public void StartShake()
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
        Vector3 currentPosition = originalPosition;

        while (currentShakeDuration > 0)
        {
            objectToShake.transform.position = currentPosition + Random.insideUnitSphere * shakeAmount;
            currentShakeDuration -= Time.deltaTime * decreaseFactor;
            yield return null;
        }

        objectToShake.transform.position = originalPosition;
        isShaking = false;
    }
}
