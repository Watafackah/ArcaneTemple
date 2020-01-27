using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
   // PlayerController miPlayer = new PlayerController();

    public float Speed = 10f;
    public float rightDirection;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
 
        if(rightDirection < 0)
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(Speed * Time.deltaTime, 0, 0);

        //if (miPlayer.movementAmount < 0)
        //    miPlayer.lookingRight = false;

        //if (miPlayer.movementAmount > 0)
        //    miPlayer.lookingRight = true;

        // transform.Translate(Speed * Time.deltaTime, 0, 0);



        /*if (Projectile != null && (contadorDisparo > 1))
            Destroy(this.gameObject, 20f);
            */
    }
}
