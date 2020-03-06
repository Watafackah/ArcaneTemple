using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int HP;
    public int HPMax = 150;
    public int MP;
    public int MPMax = 150;
    public GameObject reloadBox;

    void Start()
    {
        //reloadBox = GetComponent<Panel>();
        reloadBox = GameObject.Find("Recargaa");
    }

    void Update()
    {
        if(MP < 30)
        {
            reloadBox.gameObject.SetActive(true);
        }
        else
        {
            reloadBox.gameObject.SetActive(false);
        }

        if(Input.GetKey(KeyCode.R))
        {
            MP = MPMax;
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "Cookie")
            {
                HP -= 10;
            }
        }
    }
}
