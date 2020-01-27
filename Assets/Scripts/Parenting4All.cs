using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parenting4All : MonoBehaviour
{
    #region Declaraciones

    public GameObject player;
    public GameObject plataform;

    public bool Activo = false;

    #endregion

    #region Funciones
    public void SetParent()
    {
        if (Activo == true)
        {
            player = GameObject.FindWithTag("Player");
            player.transform.SetParent(plataform.gameObject.transform);
        }
    }

    public void Separar()
    {
        if (player != null)
        {
            player.transform.SetParent(null);
        }
    }

     void OnCollisionEnter(Collision hit)
    {
            Vector3 delante = transform.TransformDirection(Vector3.down) * 1000;
            Debug.DrawRay(transform.position, delante, Color.red);
            Activo = true;
            SetParent();
    }

    private void OnCollisionExit(Collision coll)
    {
        Activo = false;
        Separar();
    }
    #endregion
}