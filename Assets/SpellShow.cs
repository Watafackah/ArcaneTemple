using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellShow : MonoBehaviour
{
    private SpellManager1 spellManager1;
    public int magiaNumber;
    public string HabilidadFuego = "Fuego";
    public string HabilidadAgua = "Agua";
    public string HabilidadTierra = "Tierra";
    public string HabilidadViento = "Viento";
    public string HabilidadLava = "Lava1";
    public string HabilidadLava1 = "Lava2";
    public Text textbox;

    void Start()
    {
        spellManager1 = FindObjectOfType<SpellManager1>();

        textbox = GetComponent<Text>();

    }

    void Update()
    {
        magiaNumber = spellManager1.number;

        switch (spellManager1.number)
        {
            case 1:
                textbox.text = "Habilidad actual: " + HabilidadFuego;
                break;
            case 2:
                textbox.text = "Habilidad actual: " + HabilidadAgua;
                break;
            case 3:
                textbox.text = "Habilidad actual: " + HabilidadTierra;
                break;
            case 4:
                textbox.text = "Habilidad actual: " + HabilidadViento;
                break;
            case 5:
                textbox.text = "Habilidad actual: " + HabilidadLava;
                break;
            case 6:
                textbox.text = "Habilidad actual: " + HabilidadLava1;
                break;

        }
    }
}
