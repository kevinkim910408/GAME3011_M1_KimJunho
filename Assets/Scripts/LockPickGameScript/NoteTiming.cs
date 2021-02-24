using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTiming : MonoBehaviour
{
    public List<GameObject> noteList = new List<GameObject>();

    [SerializeField] Transform centerTransfrom = null;
    [SerializeField] RectTransform[] noteTimingCheckRect = null;
    Vector2[] timingBoxes = null;

    //components
    NumberControlling numberControlling;

    [SerializeField] int maxNum = 0;
    [SerializeField] int currentCount = 0;
    [SerializeField] int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        numberControlling = FindObjectOfType<NumberControlling>();

        maxNum = numberControlling.GetMaxNum();
        randomNum = Random.Range(0, maxNum);

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
        currentCount = numberControlling.GetCurrentNum();
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

                    // win condiiton
                    if(randomNum == currentCount)
                    {
                        Debug.Log("win");
                    }
                    else if(randomNum -1 == currentCount || randomNum +1 == currentCount)
                    {
                        Debug.Log("Lose HP 1");
                    }
                    else if (randomNum - 2 == currentCount || randomNum +2 == currentCount)
                    {
                        Debug.Log("Lose HP 2");
                    }
                    else if (randomNum - 3 == currentCount || randomNum + 3 == currentCount)
                    {
                        Debug.Log("Lose HP 3");
                    }
                    else
                    {
                        Debug.Log("Lose HP 4");
                    }
                    return true;
                }
            }
        }

        Debug.Log("Lose HP 5");
        return false;
    }
}
