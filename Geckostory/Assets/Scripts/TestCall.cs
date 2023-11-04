using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalReceiver : MonoBehaviour
{
    // Reference to the game object with the CamShake script
    public GameObject cameraObject;

    // Function to trigger the camera shake
    public void StartCameraShake(float duration, float amount, float decreaseFactor)
    {
        // Ensure the cameraObject has the CamShake script
        CamShake camShake = cameraObject.GetComponent<CamShake>();
        if (camShake != null)
        {
            // Set the shake parameters
            camShake.shakeDuration = duration;
            camShake.shakeAmount = amount;
            camShake.decreaseFactor = decreaseFactor;
        }


        {
            Debug.LogWarning("CamShake script not found on the cameraObject.");
        }
    }

    // Example usage of triggering the camera shake
    void Update()
    {
        // Example: Trigger camera shake on a key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCameraShake(0.5f, 0.5f, 1.0f);
        }
    }
}