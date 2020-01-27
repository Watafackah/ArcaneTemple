using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSmoothRotation : MonoBehaviour
{
    public Transform target;
    public float SpeedRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, SpeedRotation * Time.deltaTime);
        }
    }

}
