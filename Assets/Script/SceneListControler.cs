using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneListControler : MonoBehaviour
{
    public GameObject scrollView;

    public void OnOffScrollView()
    {
        if (scrollView.activeSelf.Equals(false))
        {
            scrollView.SetActive(true);
            return;
        }
        scrollView.SetActive(false);
    }

    
}
