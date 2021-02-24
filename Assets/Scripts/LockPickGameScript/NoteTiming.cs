using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    public List<GameObject> noteList = new List<GameObject>();

    [SerializeField] Transform centerTransfrom = null;
    [SerializeField] RectTransform[] noteTimingCheckRect = null;
    Vector2[] timingBoxes = null;

    // Start is called before the first frame update
    void Start()
    {
        timingBoxes = new Vector2[noteTimingCheckRect.Length];

        for(int i = 0; i < noteTimingCheckRect.Length; ++i)
        {
            timingBoxes[i].Set(centerTransfrom.localPosition.x - noteTimingCheckRect[i].rect.width / 2,
                centerTransfrom.localPosition.x + noteTimingCheckRect[i].rect.width / 2);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckTiming()
    {
        for (int i = 0; i < noteList.Count; ++i)
        {
            float t_notePosX = noteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxes.Length; ++x)
            {
                if (timingBoxes[x].x <= t_notePosX && t_notePosX <= timingBoxes[x].y)
                {
                    noteList[i].GetComponent<Note>().HideNote();
                    noteList.RemoveAt(i);
                    Debug.Log("Hit" + x);
                    return true;
                }
            }
        }

        Debug.Log("Miss");
        return false;
    }
}
