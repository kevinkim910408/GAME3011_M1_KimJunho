using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    KeyCode s = KeyCode.S;

    // components
    NoteTiming noteTiming;

    // Start is called before the first frame update
    void Start()
    {
        noteTiming = FindObjectOfType<NoteTiming>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(s))
        {
            noteTiming.CheckTiming();
        }
    }
}
