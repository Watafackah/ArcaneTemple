using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager1 : MonoBehaviour
{
    public GameObject bulletHolePrefab;
    public int spawnCount;
    public List<GameObject> bulletHoleList;

    void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject bullet = Instantiate(bulletHolePrefab) as GameObject;
            bulletHoleList.Add(bullet);
            bullet.transform.parent = this.transform;
            bullet.SetActive(false);
        }
    }
}