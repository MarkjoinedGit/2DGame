using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag
{
    private List<GameObject> items = new List<GameObject>();

    public List<GameObject> Items { get { return items; } set { items = value; } }

    private int maxSize = 0;

    public int MaxSize
    {
        get { return maxSize; }
        set
        {
            if (maxSize >= 0)
                maxSize = value;
            else maxSize = 0;
        }
    }

    private PlayerBag() { }

    private static PlayerBag instance;

    public static PlayerBag Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerBag();
                instance.maxSize = 10;
            }

            return instance;
        }
    }

    public bool addItem(GameObject item)
    {
        if (!isFullSize())
        {
            items.Add(item);
            return true;
        }
        else
            Debug.Log("Your bag is full!");
        return false;
    }

    public bool removeItem(GameObject item)
    {
        if (isContained(item))
        {
            items.Remove(item);
            return true;
        }
        Debug.Log("Item is not in my bag!");
        return false;
    }

    public bool removeItem(String name)
    {
        foreach (GameObject item in items)
        {
            if (item.name.Equals(name))
            {
                items.Remove(item);
                return true;
            }
        }
        Debug.Log("Item is not in my bag!");
        return false;
    }

    public bool removeItems(List<string> names)
    {
        int count = 0;

        foreach (string name in names)
        {
            GameObject itemToRemove = items.Find(item => item.name.Equals(name));
            if (itemToRemove != null)
                count++;
        }
        if (count != names.Count)
            return false;


        foreach (string name in names)
        {
            GameObject itemToRemove = items.Find(item => item.name.Equals(name));

            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }
        }

        return true;
    }

    public void clear()
    {
        items.Clear();
    }

    public bool isContained(GameObject item)
    {
        return items.Contains(item);
    }

    public bool isContained(String name)
    {
        foreach (GameObject item in items)
        {
            if (item.name.Equals(name))
            {
                items.Remove(item);
                return true;
            }
        }
        Debug.Log("Item is not in my bag!");
        return false;
    }

    public bool isFullSize()
    {
        return items.Count > maxSize;
    }
}
