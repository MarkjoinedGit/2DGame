using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class n_puzzle_scripts : MonoBehaviour
{
    [SerializeField]private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TileScripts[] tiles;
    private int emptySpaceIndex = 8;
    public Boolean _isFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 3)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScripts thisTile = hit.transform.GetComponent<TileScripts>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int index = findIndex(thisTile);
                    Debug.Log(tiles.Length);
                    tiles[emptySpaceIndex] = tiles[index];
                    tiles[index]  = null;
                    emptySpaceIndex = index;
                }
            }
        }

        if(!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.isInRightPlace)
                        correctTiles++;
                }
            }

            if (correctTiles == tiles.Length - 1)
            {
                _isFinished = true;
                Debug.Log("You won!!!");
            }
        }
    }

    public void Shuffle()
    {
        if (emptySpaceIndex != 8)
        {
            var tileOn8LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn8LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 8;
        }
        int inversion;
        do
        {
            for (int i = 0; i < 8; i++)
            {
                var lastPos = tiles[i].targetPosition;
                int random = UnityEngine.Random.Range(0, 7);
                tiles[i].targetPosition = tiles[random].targetPosition;
                tiles[random].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[random];
                tiles[random] = tile;
            }
            inversion = getInversion();
            Debug.Log(inversion);
            Debug.Log("Puzzle completed!!!");
        } while (inversion % 2 != 0);
    }

    int getInversion()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInversion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                        thisTileInversion++;
                }
            }
            inversionsSum += thisTileInversion;
        }
        return inversionsSum;
    }

    public int findIndex(TileScripts ts)
    {
        for (int i = 0;i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                    return i;
            }
        }

        return -1;
    }
}
