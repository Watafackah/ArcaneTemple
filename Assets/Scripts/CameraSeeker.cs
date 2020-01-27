using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSeeker : MonoBehaviour
{
    public float Speed;
    public float velocityZ;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(0, 0, velocityZ);
            transform.Rotate(0, Speed * Time.deltaTime, 0);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(0, 0, -velocityZ);
            transform.Rotate(0, -Speed * Time.deltaTime, 0);


        }

    }
}
