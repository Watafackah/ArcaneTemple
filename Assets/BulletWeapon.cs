using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : MonoBehaviour
{
    public Targ_Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision col) {

        //Targ_Health target = col.transform.GetComponent<Targ_Health>();
        Targ_Health target = FindObjectOfType<Targ_Health>();

        if (col.gameObject.tag == "Enemy")
        {
            target.TakeDamage(20.0f);
        }
    }
}
