using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private PoolManager _pool;

    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && doneWaiting)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            //anim.SetBool("Fire", true);
            municion--;
            if (municion <= 0)
            {
                Reload();
                doneWaiting = false;
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
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
        waitTime = 6f;
        //anim.SetBool("Reload", true);
        municion = maxMunicion;
    }
}
