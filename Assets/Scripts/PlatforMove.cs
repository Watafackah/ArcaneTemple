using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatforMove : MonoBehaviour
{
    #region Declaraciones

    public Transform pos1;
    public Transform pos2;

    public float velocidad;
    public float tiempo;
    float recorridoX;
    float recorridoY;
    private float tiempoinicio;
    public bool Activar = false;

    #endregion

    #region UPDATE
    void Update()
    {
        if(!Activar)
        {
            recorridoX = (Time.time * tiempoinicio) * velocidad;
            transform.position = Vector3.Lerp(pos2.position, pos1.position, recorridoX / tiempo);
        }
        
        if(Activar)
        {
            recorridoY = Mathf.PingPong(Time.time - tiempoinicio, tiempo / velocidad);
            transform.position = Vector3.Lerp(pos2.position, pos1.position, recorridoY / tiempo);
        }
    }
    #endregion
}
