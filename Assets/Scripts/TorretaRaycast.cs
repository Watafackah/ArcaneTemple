using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaRaycast : MonoBehaviour
{
    public Transform Target;
    public Rigidbody projectile;

    float distancia = 60;

    void Update()
    {

        if (Target != null)
        {
            float espacio = Vector3.Distance(transform.position, Target.position);

            if (espacio <= distancia)
            {
                transform.LookAt(Target);
                Vector3 ray = transform.TransformDirection(Vector3.forward) * 1000;
                Debug.DrawRay(transform.position, ray, Color.red);
                Rigidbody clone;
                clone = Instantiate(projectile, transform.position, transform.rotation);

                // Give the cloned object an initial velocity along the current
                // object's Z axis
                clone.velocity = transform.TransformDirection(Vector3.forward * 30);
            }
            else
            {
                ResetRot();
            }



        }
    }

    void ResetRot()
    {
        Quaternion lerpedrotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), 0.2f) ;
        transform.rotation = lerpedrotation;
    }
}
