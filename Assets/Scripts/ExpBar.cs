using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform bar1;

    private void Awake()
    {
        bar1 = transform.Find("BarExp");
    }

    public void SetSize(float sizeNormalized)
    {
        bar1.localScale = new Vector3(sizeNormalized, 1f);
    }

    public void SetColor(Color color)
    {
        bar1.Find("BarSpriteExp").GetComponent<SpriteRenderer>().color = color;
    }
}
