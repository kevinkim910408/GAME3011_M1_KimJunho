using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberControlling : MonoBehaviour
{
    [SerializeField] Text numberText = null;

    [SerializeField] int currentCount = 0;
    [SerializeField] int minCount = 0;
    [SerializeField] int maxCount = 0;

    [SerializeField] int changeCount = 1;

    [SerializeField] Text Skill_Level_Text = null;

    NoteTiming noteTiming;

    // skill level
    public enum SKILL_LEVEL { NONE, NEW, VETERAN, MASTER };
    public SKILL_LEVEL skillLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentCount = maxCount / 2;
        skillLevel = SKILL_LEVEL.NONE;

        noteTiming = FindObjectOfType<NoteTiming>();
    }

    // Update is called once per frame
    void Update()
    {
        numberText.text = currentCount.ToString();

        if (currentCount < 0)
            currentCount = 0;
        else if (currentCount > maxCount)
            currentCount = maxCount;
        if (maxCount == 0) 
        {
            noteTiming.LoseCondition();
        }
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

    public void SkillLevelSetting(int value)
    {
        switch (value)
        {
            case 0:
                skillLevel = SKILL_LEVEL.NONE;
                maxCount = 0;
                Skill_Level_Text.text = skillLevel.ToString();
                break;

            case 1:
                skillLevel = SKILL_LEVEL.NEW;
                maxCount = 10;
                Skill_Level_Text.text = skillLevel.ToString();
                break;

            case 2:
                skillLevel = SKILL_LEVEL.VETERAN;
                maxCount = 15;
                Skill_Level_Text.text = skillLevel.ToString();
                break;

            case 3:
                skillLevel = SKILL_LEVEL.MASTER;
                maxCount = 20;
                Skill_Level_Text.text = skillLevel.ToString();
                break;
        }
    }
}
