using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    [Header ("Speed")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 4f;

    [Header("Screen-position Based")]
    [SerializeField] float screenEdge = 5f;
    [SerializeField] float yMin = -4f;
    [SerializeField] float yMax = 2f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlRollFactor = 18f;
    [SerializeField] float controlPitchFactor = -5f;

    float xThrow, yThrow;
    bool playerDead = false;

	void Update () {
        if (!playerDead)
        {
            ProcessTranslation();
            ProcessRotation();
        }


    }
    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3(Mathf.Clamp(rawXPos, -screenEdge, screenEdge), transform.localPosition.y, transform.localPosition.z);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(rawYPos, yMin, yMax), transform.localPosition.z);
    }
    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw= yawDueToPosition;

        float rollDueToControl = xThrow * controlRollFactor;
        float roll=rollDueToControl;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void KillMovement()  // Called by string reference
    {
        playerDead = true;
    } 
}
