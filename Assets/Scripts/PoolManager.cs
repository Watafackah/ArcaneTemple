using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject bulletHolePrefabFuego;
    public GameObject bulletHolePrefabAgua;
    public GameObject bulletHolePrefabTierra;
    public GameObject bulletHolePrefabViento;
    public int number;
    public int spawnCount;
    public List<GameObject> bulletHoleList;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnCount; i++)
        {

            //number = Random.Range(1, 4);
            number = 1;
            switch (number)
            {
                case 1:
                    GameObject bullet = Instantiate(bulletHolePrefabFuego) as GameObject;
                    bulletHoleList.Add(bullet);
                    bullet.transform.parent = this.transform;
                    bullet.SetActive(false);
                    
                    break;
                case 2:
                    GameObject bullet1 = Instantiate(bulletHolePrefabAgua) as GameObject;
                    bulletHoleList.Add(bullet1);
                    bullet1.transform.parent = this.transform;
                    bullet1.SetActive(false);
                    break;
                case 3:
                    GameObject bullet2 = Instantiate(bulletHolePrefabTierra) as GameObject;
                    bulletHoleList.Add(bullet2);
                    bullet2.transform.parent = this.transform;
                    bullet2.SetActive(false);
                    break;
                case 4:
                    GameObject bullet3 = Instantiate(bulletHolePrefabViento) as GameObject;
                    bulletHoleList.Add(bullet3);
                    bullet3.transform.parent = this.transform;
                    bullet3.SetActive(false);
                    break;

            }
        }
    }
}
