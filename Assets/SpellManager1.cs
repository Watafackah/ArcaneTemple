using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager1 : MonoBehaviour
{
    public GameObject bulletHolePrefabFuego;
    public GameObject bulletHolePrefabAgua;
    public GameObject bulletHolePrefabTierra;
    public GameObject bulletHolePrefabViento;
    public int number;

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

    void Start()
    {
        number = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            CambioMagia();

        if (Input.GetButton("Fire1"))
        {
            nextFire = Time.time + fireRate;
            Shoot();
            //anim.SetBool("Fire", true);
            //anim.SetBool("Fire", true);
            //anim.SetBool("Idle", false);
            municion--;
            if (municion <= 0)
            {
                Reload();
                doneWaiting = false;
            }
            if (Input.GetKey(KeyCode.R) && waitTime <= 0.2 && municion < 30)
            {
                Reload();
                doneWaiting = false;
            }
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
        }
            void Shoot()
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, out hit))
            {
                Targ_Health target = hit.transform.GetComponent<Targ_Health>();
                EnemigoZombie enemigo = hit.transform.GetComponent<EnemigoZombie>();


                switch (number)
                {
                    case 1:
                        if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
                        {
                            GameObject bullet = Instantiate(bulletHolePrefabFuego) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                        }

                        break;
                    case 2:
                        if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
                        {
                            GameObject bullet = Instantiate(bulletHolePrefabAgua) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                        }
                        break;
                    case 3:
                        if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
                        {
                            GameObject bullet = Instantiate(bulletHolePrefabTierra) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                        }
                        break;
                    case 4:
                        if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
                        {
                            GameObject bullet = Instantiate(bulletHolePrefabViento) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                        }
                        break;
                }
                
            }
        }
        void CambioMagia()
        {
             number += 1;
                if(number >= 5)
            {
                number = 1;
            }
        }
        void Reload()
        {
            /*waitTime = 6f;
            //anim.SetBool("Reload", true);
            //anim.CrossFadeInFixedTime("Reload", 1f);*/
            municion = maxMunicion;
        }
    }
}
