using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScripts : MonoBehaviour
{
    public GameManager gameManager1;
    public Text textbox;

    void Start()
    {
        textbox = GetComponent<Text>();
        gameManager1 = FindObjectOfType<GameManager>();
    }

    void Update()
    {
                textbox.text = "HP : " + gameManager1.HP + "/ " +gameManager1.HPMax + "\nMP : " + gameManager1.MP + "/ " + gameManager1.MPMax;
    }
}
