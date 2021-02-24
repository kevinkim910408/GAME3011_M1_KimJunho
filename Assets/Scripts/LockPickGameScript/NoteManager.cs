using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int i_bpm = 0;
    double d_currentTime = 0.0d;

    [SerializeField] Transform noteGenerationPoint = null;
    [SerializeField] GameObject notePrefab = null;

    // Update is called once per frame
    void Update()
    {
        d_currentTime += Time.deltaTime; 

        if (d_currentTime >= 60.0d / i_bpm)
        {
            GameObject go = Instantiate(notePrefab, noteGenerationPoint.position, Quaternion.identity);
            go.transform.SetParent(this.transform);
            d_currentTime -= 60d / i_bpm;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
        }
    }

}
