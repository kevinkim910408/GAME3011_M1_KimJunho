using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle_01 : MonoBehaviour
{
    [SerializeField] GameObject modePanel;

    private bool active = false;

    private void Start()
    {
        modePanel.SetActive(false);
    }

    public void ToggleGame()
    {
        active = !active;
        modePanel.SetActive(active);
    }
}
