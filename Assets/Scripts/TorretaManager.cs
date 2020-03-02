using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaManager : MonoBehaviour
{

    public Transform target;

    float visionRange = 60;


    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            float dist = Vector3.Distance(transform.position, target.position);

            if (dist <= visionRange)
            {
                transform.LookAt(target);
            }
            else
            {
                resetrotation();
            }
        }

    }

    void resetrotation()
    {
        Quaternion lerpedrotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), 0.2f) ;


        transform.rotation = lerpedrotation;
    }
}
