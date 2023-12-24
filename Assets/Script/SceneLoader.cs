using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SceneLoader : MonoBehaviour
{ 
    public GameObject LoaderUI;
    public Slider progressSlider;

    private void Start()
    {
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadScene_Coroutine(sceneName));
    }

    public void UnloadScene(string sceneName)
    {
        StartCoroutine(UnloadScene_Coroutine(sceneName));
    }

    public void LoadNewScene(string sceneName)
    {
        StartCoroutine(LoadNewScene_Coroutine(sceneName));
    }

    public IEnumerator LoadScene_Coroutine(string sceneName)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        LoaderUI.SetActive(false);
    }

    public IEnumerator UnloadScene_Coroutine(string sceneName)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
        
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;
   
        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        LoaderUI.SetActive(false);
    }

    public IEnumerator LoadNewScene_Coroutine(string sceneName)
    {
        progressSlider.value = 0;
        LoaderUI.SetActive(true);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;
        float progress = 0;

        while (!asyncOperation.isDone)
        {
            progress = Mathf.MoveTowards(progress, asyncOperation.progress, Time.deltaTime);
            progressSlider.value = progress;
            if (progress >= 0.9f)
            {
                progressSlider.value = 1;
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
        LoaderUI.SetActive(false);
    }
}
