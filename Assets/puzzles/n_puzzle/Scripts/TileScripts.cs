using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TileScripts : MonoBehaviour
{
    public Vector3 targetPosition;
    private Vector3 correctPosition;
    public SpriteRenderer _sprite;
    public int number;
    public Boolean isInRightPlace = false;
    // Start is called before the first frame update
    void Awake()
    {
        targetPosition = transform.position;
        correctPosition = transform.position;
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.15f);
        if (targetPosition == correctPosition)
        {
            isInRightPlace = true;
            _sprite.color = Color.green;
        }
        else
        {
            isInRightPlace = false;
            _sprite.color = Color.white;
        }
    }
}
