using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour1 : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("OnDisable", 3.0f);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
        this.transform.gameObject.SetActive(false);
        Debug.Log("Destruyendo bala");


    }
}
