using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camDadMovement : MonoBehaviour
{
    public Transform bus;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = bus.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = bus.transform.rotation;
        transform.position = bus.transform.position;
    }
}