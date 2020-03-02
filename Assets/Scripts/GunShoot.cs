using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GunShoot : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] public GameObject BulletHole;

    public Camera cam;
    public float damage;
    public float range;
    public float impactForce;
    public float fireRate;
    public float nextFire;
    public float waitTime = 6.0f;
    public int municion;
    public int maxMunicion;
    public bool doneWaiting = true;

    public Transform Spawn;
    public Rigidbody projectile;

    private PoolManager1 _pool;

    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager1>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && doneWaiting)
        {
            Debug.Log("Disparando...");
            nextFire = Time.time + fireRate;
            Shoot();
            Vector3 ray = transform.TransformDirection(Vector3.forward) * 1000;
            Debug.DrawRay(transform.position, ray, Color.red);
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);

            clone.velocity = transform.TransformDirection(Vector3.forward * 30);
            municion--;
            if (municion <= 0)
            {
                Reload();
                doneWaiting = false;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Reloading...");
            Reload();
            doneWaiting = false;


        }
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Done");
            doneWaiting = true;

        }
    }




    void Shoot()
    {
        Debug.Log("Shooting...");
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, out hit))
        { 
                Vector3 direction = hit.point - cam.transform.position;
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        
    }

    void Reload()
    {
        Debug.Log("Reloaded!");
        waitTime = 3f;
        municion = maxMunicion;
    }
}
