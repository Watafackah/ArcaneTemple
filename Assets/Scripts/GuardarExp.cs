using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarExp : MonoBehaviour
{
    public static GuardarExp instance;
    public Transform player1;
    public int nivelGuardado;

    private void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
       // player1 = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
  /*  public void GuardarXp()
    {
        LevelingSystem script2 = player1.GetComponent<LevelingSystem>();
        nivelGuardado = script2.nivelPlayer;
    }

    public void CargarXp()
    {
        LevelingSystem script3 = player1.GetComponent<LevelingSystem>();
         script3.nivelPlayer = nivelGuardado;
    }*/
}
