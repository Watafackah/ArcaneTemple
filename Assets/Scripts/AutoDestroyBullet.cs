using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyBullet : MonoBehaviour
{
    public float TimeToLive = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
