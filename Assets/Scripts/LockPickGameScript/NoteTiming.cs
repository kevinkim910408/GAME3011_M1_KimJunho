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

    // conditions - win/ lose
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject losePanel = null;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

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
                        WInCondition();
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

    public void WInCondition()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void LoseCondition()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
