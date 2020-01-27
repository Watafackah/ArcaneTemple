using UnityEngine;
using System.Collections;

public enum Type
{
    NULL,
    COSUMABLE,
    EQUIPAMENT
}

[System.Serializable]
public class Itens : MonoBehaviour
{
    public string names;
    public string attributes;
    public int valueBuy;
    public int valueSell;

    public int amount;
    public Sprite icons;
    public GameObject itemDrop;
    public Sprite iconsNeutral;
    public Type type;

    public Itens(string name, string attributes, int valueBuy, int valueSell, Type _type)
    {
        this.names = name;
        this.attributes = attributes;
        this.valueBuy = valueBuy;
        this.valueSell = valueSell;
        this.type = _type;
        this.itemDrop = Resources.Load<GameObject>("Prefabs/DropItens/" + names);
        this.icons = Resources.Load<Sprite>("Icons/" + names);
        this.iconsNeutral = Resources.Load<Sprite>("Icons/IconsNeutral/" + names);
    }

    public Itens()
    {
    }
}
