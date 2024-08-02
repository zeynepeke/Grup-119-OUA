using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovementLimiter : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float maxXAxisSpeed = 5f;
    public float maxYAxisSpeed = 3f;

    private void Update()
    {
        if (freeLookCamera != null)
        {
            // X Axis
            float currentXAxisValue = freeLookCamera.m_XAxis.Value;
            currentXAxisValue = Mathf.Clamp(currentXAxisValue, -maxXAxisSpeed, maxXAxisSpeed);
            freeLookCamera.m_XAxis.Value = currentXAxisValue;

            // Y Axis
            float currentYAxisValue = freeLookCamera.m_YAxis.Value;
            currentYAxisValue = Mathf.Clamp(currentYAxisValue, -maxYAxisSpeed, maxYAxisSpeed);
            freeLookCamera.m_YAxis.Value = currentYAxisValue;
        }
    }
}

