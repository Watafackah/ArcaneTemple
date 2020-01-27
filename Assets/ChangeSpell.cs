using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpell : MonoBehaviour
{
    private PoolManager _pool;

    // Start is called before the first frame update
    void Start()
    {
        _pool = GameObject.FindObjectOfType<PoolManager>();
    }

    void Update()
    {
        //Output this to console when the Button is clicked
        if (Input.GetKeyDown(KeyCode.C))
        {
            _pool.number += 1;
            _pool.spawnCount = 0;
            _pool.spawnCount = 1;
        }
        if (_pool.number >= 5)
            _pool.number = 1;

    }
}
