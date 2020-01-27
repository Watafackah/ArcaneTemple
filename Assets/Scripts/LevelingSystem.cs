using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    public Transform player1;
    //public GameObject LevelingUp;
    //public GameObject LaunchPositionLvlUp;
    public GuardarExp exp1;
    public LevelingSystem instance;
    public int XP;
    public int nivelPlayer;
    public int ExpRestante;
    public int ExpNextLevel;
    public int DiferenciaToTal;
    public float porcentaje;
    public int VIDAMAX;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
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

        nivelPlayer = PlayerPrefs.GetInt("PlayerCurrentLevel");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXp(0);
    }

    public void UpdateXp(int xp)
    {
        XP += xp;
        int nivel = (int)(0.1f * Mathf.Sqrt(XP));
        if( nivel != nivelPlayer)
        {
            nivelPlayer = nivel;
            //Instantiate(LevelingUp, LaunchPositionLvlUp.transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("PlayerCurrentLevel", nivelPlayer);
            player1 = GameObject.FindGameObjectWithTag("Player").transform;
            //script2.vida = script2.vidaMax;
            
        }
        if (nivelPlayer == 0)
        {
            ExpNextLevel = 100;
        }
        else
        {
            ExpNextLevel = 100 * (nivelPlayer + 1) * (nivelPlayer + 1);
        }
       
        ExpRestante = ExpNextLevel - XP;
        if (XP != 0)
        {
            porcentaje = ((float)XP) / (float)ExpNextLevel;
            Debug.Log(ExpRestante + " " + XP + " " + porcentaje);
        }

        else
        {
            porcentaje = 0;
            Debug.Log(XP);
        }

        DiferenciaToTal = ExpNextLevel - (100 * nivelPlayer * nivelPlayer);
    }
}
