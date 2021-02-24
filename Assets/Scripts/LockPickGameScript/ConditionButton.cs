using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionButton : MonoBehaviour
{
    //public string restartScene;
    public void GoExit()
    {
        // editor quit
        UnityEditor.EditorApplication.isPlaying = false;

        // application quit
        Application.Quit();
        //SceneManager.LoadScene(restartScene);
    }
}
