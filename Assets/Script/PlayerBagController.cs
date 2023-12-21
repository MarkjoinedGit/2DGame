using Microsoft.Unity.VisualStudio.Editor;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class PlayerBagController : MonoBehaviour
{
    public GameObject scrollview;
    public GameObject scrollviewContainer;
    public PlayerBag playerBag;

    void Start()
    {
        playerBag = PlayerBag.Instance;
    }

    public void OnOffscrollview()
    {
        if (scrollview.activeSelf)
            scrollview.SetActive(false);
        else
        {
            LoadItemsInPlayerBag();
            scrollview.SetActive(true);
        } 
    }

    public void LoadItemsInPlayerBag()
    {
        for (int i = 0; i < playerBag.Items.Count; i++)
        {
            GameObject itemSlot = scrollviewContainer.transform.GetChild(i).gameObject;
            DestroyChildrenObjects(itemSlot);
            ConvertGraphicToImage(itemSlot, playerBag.Items[i].GetComponent<Button>().targetGraphic);
        }
      
    }

    private void ConvertGraphicToImage(GameObject parent, Graphic graphic)
    {
        Debug.Log("Item name: " + graphic.name);
        SVGImage graphicImage = graphic.GetComponent<SVGImage>();
        if (graphicImage != null)
        {
            GameObject imageObject = new GameObject("BagItem");
            SVGImage imageComponent = imageObject.AddComponent<SVGImage>();
            imageComponent.sprite = graphicImage.sprite;
            imageComponent.preserveAspect = true;
            imageObject.transform.SetParent(parent.transform);
        }
        else
        {
            Debug.LogError("The 'graphic' does not have an Image component.");
        }
    }
    void DestroyChildrenObjects(GameObject gameObject)
    {
        int childCount = gameObject.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(gameObject.transform.GetChild(i).gameObject);
        }
    }

}

