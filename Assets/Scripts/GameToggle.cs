using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    [SerializeField] 
    private GameObject canvas;

    private bool active = false;

    public void ToggleGame()
    {
        active = !active;
        canvas.SetActive(active);
    }
}
