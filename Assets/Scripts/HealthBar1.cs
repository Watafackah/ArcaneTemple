using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar1 : MonoBehaviour {

    private Transform bar;
    public static HealthBar1 instance;


    private void Awake () {
        bar = transform.Find("Bar");

	}

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(this);
        }
    }

    public void SetSize(float sizeNormalized) {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color) {
        bar.Find("BarSprite").GetComponent<SpriteRenderer>().color = color;
    }
}
