using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tiles : MonoBehaviour, IPointerClickHandler
{
    [Header("Tiles")]
    [SerializeField] int row, col;
    [SerializeField] bool isMaxTile = false;
    [SerializeField] bool isQuaterTile = false;
    [SerializeField] bool isHalfTile = false;
    [SerializeField] Image tileImage = null;
    [SerializeField] Color tileColor = Color.white;

    [Header("Resources")]
    [SerializeField] float tileResource = 0f;
    [SerializeField] float maxResource = 5000f;

    public enum RESOURCE_LEVEL { ZERO, QUATER, HALF, MAX, END }; // zero = 0, end = 5
    //Color[] tileColorArr = new Color[4];
    Color[] tileColorArr = new Color[(int)RESOURCE_LEVEL.END];
    public RESOURCE_LEVEL currentResourceLevel = RESOURCE_LEVEL.ZERO;

    private void Awake()
    {
        tileImage = GetComponent<Image>();

        tileColorArr[(int)RESOURCE_LEVEL.ZERO] = Color.white;
        tileColorArr[(int)RESOURCE_LEVEL.QUATER] = Color.green;
        tileColorArr[(int)RESOURCE_LEVEL.HALF] = Color.yellow;
        tileColorArr[(int)RESOURCE_LEVEL.MAX] = Color.red;
    }

    public void SetGridIndices(int r, int c)
    {
        row = r;
        col = c;
    }

    public void IsMaxTile()
    {
        isMaxTile = true;
        currentResourceLevel = RESOURCE_LEVEL.MAX;
    }
    public void IsQuaterTile()
    {
        isQuaterTile = true;
        currentResourceLevel = RESOURCE_LEVEL.QUATER;
    }
    public void IsHalfTile()
    {
        isHalfTile = true;
        currentResourceLevel = RESOURCE_LEVEL.HALF;
    }
    public void SetColor(Color color)
    {
        tileColor = color;
    }
    public void SetResource()
    {
        if (isMaxTile) tileResource = maxResource;
        else if (isHalfTile) tileResource = maxResource * 0.5f;
        else if (isQuaterTile) tileResource = maxResource * 0.25f;
    }
    public void OpenTileColor()
    {
        tileImage.color = tileColor;
    }

    public float GetResources()
    {
        return tileResource;
    }

    public void ExtractTile()
      {
    //    if (isMaxTile)
    //    {
    //        currentResourceLevel = 
    //        SetColor(tileColorArr[(int)RESOURCE_LEVEL.HALF]);
    //    }
    //    else if (isHalfTile)
    //    {
    //        SetColor(tileColorArr[(int)RESOURCE_LEVEL.QUATER]);
    //    }
    //    else if (isQuaterTile)
    //    {
    //        SetColor(tileColorArr[(int)RESOURCE_LEVEL.ZERO]);
    //    }


        RESOURCE_LEVEL downLevel = currentResourceLevel - 0;

        switch (downLevel)
        {
            case RESOURCE_LEVEL.MAX:
                SetColor(tileColorArr[(int)RESOURCE_LEVEL.HALF]);
                break;
            case RESOURCE_LEVEL.HALF:
                SetColor(tileColorArr[(int)RESOURCE_LEVEL.QUATER]);
                break;
            case RESOURCE_LEVEL.QUATER:
                SetColor(tileColorArr[(int)RESOURCE_LEVEL.ZERO]);
                break;
            case RESOURCE_LEVEL.ZERO:
                SetColor(tileColorArr[(int)RESOURCE_LEVEL.ZERO]);
                break;
        }
    }
   

    public void OnPointerClick(PointerEventData eventData)
    {
        if(miniGame.instance.currentMode == miniGame.MODE.SCAN)
            miniGame.instance.ScanMode(row, col);
        else if(miniGame.instance.currentMode == miniGame.MODE.EXTRACT)
            miniGame.instance.ExtractMode(row, col);
    }

}
