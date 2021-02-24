using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConditionButton : MonoBehaviour
{
    public string restartScene;
    public void GoExit()
    {
        SceneManager.LoadScene(restartScene);
    }
}
