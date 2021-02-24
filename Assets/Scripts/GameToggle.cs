using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    [SerializeField] GameObject modePanel;
    [SerializeField] GameObject gamePanel;

    private bool active = false;

    private void Start()
    {
        modePanel.SetActive(false);
        gamePanel.SetActive(false);
    }

    public void ToggleGame()
    {
        active = !active;
        modePanel.SetActive(active);
    }

    public void StartGame()
    {
        modePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
