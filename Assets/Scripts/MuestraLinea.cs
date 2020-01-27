using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraLinea : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnDrawGizmosSelected();
    }

    public void OnDrawGizmosSelected()
    {
       
          Gizmos.color = Color.blue;
          Gizmos.DrawLine(transform.position, target.position);
        
    }
}
