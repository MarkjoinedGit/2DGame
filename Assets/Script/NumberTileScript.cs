using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberTileScript : MonoBehaviour
{
    private int number;

    public int Number { get => number; set => number=value; }

    // Start is called before the first frame update
    void Start()
    {
        number = Convert.ToInt16(gameObject.name);
;   }
}
