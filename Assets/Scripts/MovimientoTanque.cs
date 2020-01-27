using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTanque : MonoBehaviour
{
    #region Declaraciones

    public float speed = 0.5f;
    public float backwardspeed = 0.33f;
    public float angularspeed = 1;
    public float upspeed = 5;
    public float downspeed = 4;
    public float rotatespeed = 1;
    float horizontal;
    float vertical;
    public GameObject torreta;

    #endregion

    #region Update
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Q) == true)
        {
            torreta.transform.Rotate(Vector3.down * 2);
        }
        if (Input.GetKey(KeyCode.E) == true)
        {
            torreta.transform.Rotate(Vector3.up * 2);
        }
        if (vertical == 1)
        {
            gameObject.transform.Translate(Vector3.forward * speed);
        }
        if (vertical == -1)
        {
            gameObject.transform.Translate(Vector3.back * speed * backwardspeed);
        }
        if (horizontal == 1)
        {
            gameObject.transform.Rotate(Vector3.up * angularspeed);
        }
        if (horizontal == -1)
        {
            gameObject.transform.Rotate(Vector3.down * angularspeed);
        }
    }
    #endregion
}
