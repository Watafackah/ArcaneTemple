using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaRaycast : MonoBehaviour
{
    [SerializeField] public float shootDuration;
    public Transform Target;
    public Rigidbody projectile;

    float distancia = 30;

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
                new WaitForSeconds(shootDuration);
                clone = Instantiate(projectile, transform.position, transform.rotation);

                clone.velocity = transform.TransformDirection(Vector3.forward * 25);
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
