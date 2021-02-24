using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int up_bpm = 0;
    double d_currentTime_01 = 0.0d;

    [SerializeField] Transform noteGenerationPoint = null;
    [SerializeField] GameObject notePrefab = null;


    // components
    NoteTiming noteTiming;


    private void Start()
    {
        noteTiming = FindObjectOfType<NoteTiming>();
    }

    // Update is called once per frame
    void Update()
    {
        d_currentTime_01 += Time.deltaTime;


        //first
        if (d_currentTime_01 >= 60.0d / up_bpm)
        {

            GameObject go = Instantiate(notePrefab, noteGenerationPoint.position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            noteTiming.noteList.Add(go);
            d_currentTime_01 -= 60d / up_bpm;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
           // noteTiming.currentLockPickHP -= 5;
            Debug.Log("Lose HP 5");
            noteTiming.noteList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
