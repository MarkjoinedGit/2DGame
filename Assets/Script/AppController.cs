using UnityEngine;

public class AppController : MonoBehaviour
{
    public void QuitGame()
    {
    
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
