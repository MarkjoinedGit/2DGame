using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneListControler : MonoBehaviour
{
    public GameObject scrollView;
    public GameObject scrollViewContainer;
    private Player player;

    void Start()
    {   
        player = Player.Instance;
    }

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
