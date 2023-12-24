using UnityEngine;
using UnityEngine.UI;

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
        highLightSceneFinish();
        if (scrollView.activeSelf.Equals(false))
        {
            scrollView.SetActive(true);
            return;
        }
        scrollView.SetActive(false);
    }

    public void highLightSceneFinish()
    {
        for (int i = 0; i < player.ScenesAreFinished.Count; i++)
        {
            if (scrollViewContainer.transform.GetChild(i).gameObject.CompareTag(player.ScenesAreFinished[i]))
            {
                scrollViewContainer.transform.GetChild(i).gameObject.GetComponent<Image>().color = Color.green;
            }
        }
    }
}
