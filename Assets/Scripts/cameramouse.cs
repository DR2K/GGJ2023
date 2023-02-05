using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramouse : MonoBehaviour
{
    public float sensitivity = 100f;
    private float cameraDistance = 10f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Transform parent = transform.parent.transform;
        transform.position = parent.position - parent.forward * cameraDistance;
        transform.LookAt(parent.position);
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }

    private void LateUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 15f)
        {
            Transform parent = transform.parent.transform;
            transform.position = parent.position - parent.forward * cameraDistance;
            transform.LookAt(parent.position);
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }

        transform.LookAt(transform.parent.transform.position);
        
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        if (rotateVertical != 0 || rotateHorizontal != 0)
        {
            timer = 0f;
        }

        rotateHorizontal *= sensitivity;
        rotateVertical *= sensitivity;

        transform.RotateAround(transform.parent.position, Vector3.up, rotateHorizontal);
        transform.RotateAround(transform.parent.position, transform.right, -rotateVertical);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}