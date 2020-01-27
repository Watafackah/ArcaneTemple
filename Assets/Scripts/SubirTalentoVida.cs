using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubirTalentoVida : MonoBehaviour
{

    //AumentarVidaMax vidaMax;
    public Transform player1;
    public int TalentosEnVida1;

    public void SubirTalentoEnVidaFunct()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").transform;
        //PlayerController script2 = player1.GetComponent<PlayerController>();
        TalentosEnVida1++;
        

        //vidaMax.TalentosEnVida++;
    }
}
