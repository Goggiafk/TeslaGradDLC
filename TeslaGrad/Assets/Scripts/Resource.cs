using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourcesType
{
    Wood,
    Metal,
    Foto,
    Accum,
}

public class Resource : MonoBehaviour
{
    public ResourcesType type;
    public Sprite icon;
    public float weight;
    public int count;

    public Resource(ResourcesType type)
    {
        this.type = type;
        Resources.Load<Sprite>("Sprites/" + type);
        switch (type)
        {
            case ResourcesType.Wood:
                weight = 10;
                break;
            case ResourcesType.Metal:
                weight = 100;
                break;
            case ResourcesType.Foto:
                weight = 250;
                break;
            case ResourcesType.Accum:
                weight = 500;
                break;
            default:
                break;
        }
    }
}
