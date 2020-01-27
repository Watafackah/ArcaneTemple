using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThings : MonoBehaviour
{
    public Transform Handed;

    void OnMouseDrag()
    {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = Handed.transform.position;
        this.transform.parent = GameObject.FindWithTag("Player").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
