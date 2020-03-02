using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SpellManager1 : MonoBehaviour
{
    public GameObject bulletHolePrefabFuego;
    public GameObject bulletHolePrefabAgua;
    public GameObject bulletHolePrefabTierra;
    public GameObject bulletHolePrefabViento;
    public GameObject redSpellTerrain;
    public GameObject hitBall;
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

    public GameManager manager;

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
                        if (hit.collider.tag == "World" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabFuego) as GameObject;                           
                            bullet.transform.position = hit.point;                            
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);                            
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 1] Gastas 10 puntos de Mana");
                            
                        }

                        break;
                    case 2:
                        if (hit.collider.tag == "World" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabAgua) as GameObject;                            
                            bullet.transform.position = hit.point;                            
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);                          
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 2] Gastas 10 puntos de Mana");

                        }
                        break;
                    case 3:
                        if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabTierra) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 3] Gastas 10 puntos de Mana");
                        }
                        break;
                    case 4:
                        if (hit.collider.tag == "World" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(30.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabViento) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 4] Gastas 10 puntos de Mana");
                        }
                        break;
                    case 5:
                        if (hit.collider.tag == "World" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(50.0f);
                            GameObject bullet = Instantiate(redSpellTerrain) as GameObject;
                            GameObject bullet1 = Instantiate(hitBall) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet1.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(-hit.normal);
                            bullet1.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                            bullet1.transform.parent = this.transform;
                            Debug.Log("[Habilidad 5] Gastas 20 puntos de Mana");
                        }
                        break;
                    case 6:
                        if (hit.collider.tag == "World" || hit.collider.tag == "Enemy")
                        {
                            target.TakeDamage(50.0f);
                            GameObject bullet = Instantiate(redSpellTerrain) as GameObject;
                            GameObject bullet1 = Instantiate(hitBall) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet1.transform.position = cam.transform.position;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet1.transform.rotation = Quaternion.LookRotation(cam.transform.position);
                            bullet.transform.parent = this.transform;
                            bullet1.transform.parent = this.transform;
                            Debug.Log("[Habilidad 6] Gastas 30 puntos de Mana");
                        }
                        break;
                } 
            }
        }
        void CambioMagia()
        {
             number += 1;
                if(number >= 7)
            {
                number = 1;
            }
        }
        void Reload()
        {
            municion = maxMunicion;
        }
    }
}
