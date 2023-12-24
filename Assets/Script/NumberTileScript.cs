using System;
using UnityEngine;

public class NumberTileScript : MonoBehaviour
{
    private int number;
    public int Number { get => number; set => number=value; }

    void Start()
    {
        number = Convert.ToInt16(gameObject.name);
    }
}
