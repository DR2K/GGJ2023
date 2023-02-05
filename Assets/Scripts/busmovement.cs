using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class busmovement : MonoBehaviour
{
    
    
    
    public float speed = 0;
    private Rigidbody rbBus;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    
    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rbBus = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);

        rbBus.MovePosition(rbBus.position + movement * speed * Time.fixedDeltaTime);
        rbBus.MoveRotation(targetRotation);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0f;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            currentAcceleration = acceleration;
        }
        else
        {
            currentAcceleration = 0f;
        }

    }
}