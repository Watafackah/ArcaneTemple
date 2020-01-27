using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targ_Health : MonoBehaviour
{
    public float vida = 100f;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage (float amnt)
    {
        print("Recibe daño " + amnt.ToString() + "-Targ Health");

        vida -= 20f;

        if (vida == 0)
        {
            Destroy(gameObject);
        }
    }
}
