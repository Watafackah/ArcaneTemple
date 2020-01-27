using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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
    private EnemigoZombie zombie;

    void Start()
    {
        //anim = GetComponent<Animator>();
        _pool = GameObject.FindObjectOfType<PoolManager>();
        zombie = FindObjectOfType<EnemigoZombie>();

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire && doneWaiting)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            //anim.SetBool("Fire", true);
            //anim.SetBool("Fire", true);
            //anim.SetBool("Idle", false);
            municion--;
            if(municion <= 0)
            {
                Reload();
                doneWaiting = false;
            }
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

            //FUEGO
            if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
            {
                if (_pool.number == 1)
                {
                    for (int i = 0; i < _pool.bulletHoleList.Count; i++)
                    {
                        if (_pool.bulletHoleList[i].activeInHierarchy == false)
                        {
                            _pool.bulletHoleList[i].SetActive(true);
                            _pool.bulletHoleList[i].transform.position = hit.point;
                            _pool.bulletHoleList[i].transform.rotation = Quaternion.LookRotation(hit.normal);
                            break;
                        }
                        else
                        {
                            if (i == _pool.bulletHoleList.Count - 1)
                            {
                                GameObject newBullet = Instantiate(_pool.bulletHolePrefabFuego) as GameObject;
                                newBullet.transform.parent = _pool.transform;
                                newBullet.SetActive(false);
                                _pool.bulletHoleList.Add(newBullet);
                            }
                        }
                    }
                    Vector3 direction = hit.point - cam.transform.position;
                    //cam.transform.rotation = Quaternion.LookRotation(direction);

                    if (hit.collider.tag == "Enemy")
                    {
                        //zombie.Vida -= 10;
                        enemigo.Vida -= 50;
                        enemigo.rgb.detectCollisions = false;
                    }
                }
            }

            //Agua
            if (hit.collider.tag == "Untagged" || hit.collider.tag == "Enemy")
            {
                if (_pool.number == 2)
                {
                    for (int i = 0; i < _pool.bulletHoleList.Count; i++)
                    {
                        if (_pool.bulletHoleList[i].activeInHierarchy == false)
                        {
                            _pool.bulletHoleList[i].SetActive(true);
                            _pool.bulletHoleList[i].transform.position = hit.point;
                            _pool.bulletHoleList[i].transform.rotation = Quaternion.LookRotation(hit.normal);
                            break;
                        }
                        else
                        {
                            if (i == _pool.bulletHoleList.Count - 1)
                            {
                                GameObject newBullet = Instantiate(_pool.bulletHolePrefabAgua) as GameObject;
                                newBullet.transform.parent = _pool.transform;
                                newBullet.SetActive(false);
                                _pool.bulletHoleList.Add(newBullet);
                            }
                        }
                    }
                    Vector3 direction = hit.point - cam.transform.position;
                    //cam.transform.rotation = Quaternion.LookRotation(direction);

                    if (hit.collider.tag == "Enemy")
                    {
                        //zombie.Vida -= 10;
                        enemigo.Vida -= 50;
                        enemigo.rgb.detectCollisions = false;
                    }
                }
            }
        

            if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
        }

        void Reload()
        {
        waitTime = 6f;
        //anim.SetBool("Reload", true);
        //anim.CrossFadeInFixedTime("Reload", 1f);
        municion = maxMunicion;
        }
    } 

