using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRightWheel;
    [SerializeField] WheelCollider frontLeftWheel;
    [SerializeField] WheelCollider backRightWheel;
    [SerializeField] WheelCollider backLeftWheel;

    public float acceleration = 3000f;
    public float breakingForce = 1500f;
    public float maxTurnAngle = 40f;

    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            currentBreakingForce = breakingForce;
        else
            currentBreakingForce = 0f;

        frontRightWheel.motorTorque = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;

        frontRightWheel.brakeTorque = currentBreakingForce;
        frontLeftWheel.brakeTorque = currentBreakingForce;
        backRightWheel.brakeTorque = currentBreakingForce;
        backLeftWheel.brakeTorque = currentBreakingForce;
        
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;
    }
}