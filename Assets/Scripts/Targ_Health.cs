using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targ_Health : MonoBehaviour
{
    public float vida = 100f;
    public GameManager manager;

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
