using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private PlayerBag bag;
    private List<string> scenesAreFinished;
    private static Player instance;

    public PlayerBag Bag { get { return bag; }}
    public List<string> ScenesAreFinished {  get { return scenesAreFinished; }}
    public static Player Instance 
    {
        get 
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance; 
        }
    
    }

    private Player()
    {
        bag = new PlayerBag();
        scenesAreFinished = new List<string>();
    }


}
