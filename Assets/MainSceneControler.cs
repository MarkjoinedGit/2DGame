using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene mainScene = SceneManager.GetActiveScene();
        GameObject[] gameObjects = mainScene.GetRootGameObjects();
        foreach (GameObject gameObject in gameObjects)
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDisable()
    {
        
    }
    private void OnEnable()
    {
       
    }
}
