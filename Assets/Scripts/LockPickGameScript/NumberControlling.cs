using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberControlling : MonoBehaviour
{
    [SerializeField] Text numberText = null;

    [SerializeField] int currentCount = 0;
    [SerializeField] int minCount = 0;
    [SerializeField] int maxCount = 10;

    [SerializeField] int changeCount = 1;



    // Start is called before the first frame update
    void Start()
    {
        currentCount = maxCount / 2;
    }

    // Update is called once per frame
    void Update()
    {
        numberText.text = currentCount.ToString();

        if (currentCount < 0)
            currentCount = 0;
        else if (currentCount > maxCount)
            currentCount = maxCount;
    }

    public int GetMinNum()
    {
        return minCount;
    }
    public int GetMaxNum()
    {
        return maxCount;
    }
    public int GetCurrentNum()
    {
        return currentCount;
    }

    public void PressUpBtn()
    {
        currentCount += changeCount;
    }

    public void PressDownBtn()
    {
        currentCount -= changeCount;
    }
}
