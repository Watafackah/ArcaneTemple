using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ExpBar ExpBar1;
    public float exp;
    private GuardarExp exp1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= .01f)
        {
            ExpBar1.SetSize(0.1f);
        }

    }
}
