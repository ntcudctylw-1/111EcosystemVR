using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PcWalking : MonoBehaviour
{

    public bool isWalking;
#if UNITY_STANDALONE_WIN
    public static XRIDefaultInputActions inputActions;


    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
            this.enabled = false;
        else
        {
            inputActions = new XRIDefaultInputActions();
            inputActions.Enable();
        }
        
    }
    void Update()
    {
        isWalking = false;
        if (inputActions.PCControll.Movement.ReadValue<Vector2>().y > 0)
        {
            isWalking = true;
        }
        CameraRotation();
    }


    private const float _threshold = 0.01f;
    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;
    // cinemachine
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;
    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;
    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    private void CameraRotation()
    {
        // if there is an input and camera position is not fixed
        if (inputActions.PCControll.Look.ReadValue<Vector2>().sqrMagnitude >= _threshold && !LockCameraPosition)
        {
            //Don't multiply mouse input by Time.deltaTime;
            float deltaTimeMultiplier = 1.0f;

            _cinemachineTargetYaw += inputActions.PCControll.Look.ReadValue<Vector2>().x * deltaTimeMultiplier;
            _cinemachineTargetPitch += inputActions.PCControll.Look.ReadValue<Vector2>().y * deltaTimeMultiplier;
        }

        // clamp our rotations so our values are limited 360 degrees
        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        // Cinemachine will follow this target
        //print(Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,_cinemachineTargetYaw, 0.0f));
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
#endif
}
