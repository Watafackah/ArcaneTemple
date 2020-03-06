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
    public GameObject ManoFuegoPart;
    public GameObject ManoAguaPart;
    public GameObject ManoTierraPart;
    public GameObject ManoVientoPart;
    public int number;
    private GameManager gameManager;

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
    public Transform Hand;
    public int contadorHand = 1;

    public GameManager manager;

    void Start()
    {
        ManoFuegoPart = GameObject.FindGameObjectWithTag("HandParts1");
        ManoAguaPart = GameObject.FindGameObjectWithTag("HandParts2");
        ManoTierraPart = GameObject.FindGameObjectWithTag("HandParts3");
        ManoVientoPart = GameObject.FindGameObjectWithTag("HandParts4");
        number = 1;
        GameObject.Find("ManoAguaPart").SetActive(false);
        GameObject.Find("ManoTierraPart").SetActive(false);
        GameObject.Find("ManoVientoPart").SetActive(false);

        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            CambioMagia();
            contadorHand++;

            if (contadorHand >= 7)
            {
                contadorHand = 1;
            }
        }

        switch (contadorHand)
        {
            case 1:
                ManoFuegoPart.SetActive(true);
                ManoVientoPart.SetActive(false);
                break;
            case 2:

                ManoFuegoPart.SetActive(false);
                ManoAguaPart.SetActive(true);
                break;
            case 3:
                ManoAguaPart.SetActive(false);
                ManoTierraPart.SetActive(true);
                break;
            case 4:
                ManoTierraPart.SetActive(false);
                ManoVientoPart.SetActive(true);
                break;
            case 5:
                ManoFuegoPart.SetActive(true);
                ManoTierraPart.SetActive(false);
                break;
            case 6:
                ManoFuegoPart.SetActive(true);
                ManoTierraPart.SetActive(false);
                break;
        }


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
                        if (hit.collider.tag == "World" && gameManager.MP > 11 || hit.collider.tag == "Enemy" && gameManager.MP > 11)
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabFuego) as GameObject;                           
                            bullet.transform.position = hit.point;                            
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);                            
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 1] Gastas 5 puntos de Mana");
                            gameManager.MP -= 5;
                            
                        }

                        break;
                    case 2:
                        if (hit.collider.tag == "World" && gameManager.MP >= 11 || hit.collider.tag == "Enemy" && gameManager.MP >= 11)
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabAgua) as GameObject;                            
                            bullet.transform.position = hit.point;                            
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);                          
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 2] Gastas 5 puntos de Mana");
                            gameManager.MP -= 5;

                        }
                        break;
                    case 3:
                        if (hit.collider.tag == "Untagged" && gameManager.MP >= 11 || hit.collider.tag == "Enemy" && gameManager.MP >= 11)
                        {
                            target.TakeDamage(20.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabTierra) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 3] Gastas 5 puntos de Mana");
                            gameManager.MP -= 5;
                        }
                        break;
                    case 4:
                        if (hit.collider.tag == "World" && gameManager.MP >= 11 || hit.collider.tag == "Enemy" && gameManager.MP >= 11)
                        {
                            target.TakeDamage(30.0f);
                            GameObject bullet = Instantiate(bulletHolePrefabViento) as GameObject;
                            bullet.transform.position = hit.point;
                            bullet.transform.rotation = Quaternion.LookRotation(hit.normal);
                            bullet.transform.parent = this.transform;
                            Debug.Log("[Habilidad 4] Gastas 5 puntos de Mana");
                            gameManager.MP -= 5;
                        }
                        break;
                    case 5:
                        if (hit.collider.tag == "World" && gameManager.MP >= 30 || hit.collider.tag == "Enemy" && gameManager.MP >= 30)
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
                            Debug.Log("[Habilidad 5] Gastas 15 puntos de Mana");
                            gameManager.MP -= 15;
                        }
                        break;
                    case 6:
                        if (hit.collider.tag == "World" && gameManager.MP >= 30 || hit.collider.tag == "Enemy" && gameManager.MP >= 30)
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
                            Debug.Log("[Habilidad 6] Gastas 15 puntos de Mana");
                            gameManager.MP -= 15;
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
