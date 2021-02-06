using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miniGame : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] int tileRow = 32;
    [SerializeField] int tileCol = 32;
    [SerializeField] int gridSpace = 1;

    [Header("Counts")]
    [SerializeField] int myReourceCount = 0;
    [SerializeField] int currentScanCount = 0;
    [SerializeField] int maxScanCount = 6;
    [SerializeField] int currentExtractCount = 0;
    [SerializeField] int maxExtractCount = 3;
    [SerializeField] float currentResourceCount = 0;

    [Header("Scan / Extract")]
    [SerializeField] GameObject scanBtn = null;
    [SerializeField] GameObject extractBtn = null;
    [SerializeField] public enum MODE {SCAN, EXTRACT, END };
    [SerializeField] public MODE currentMode = MODE.EXTRACT;
    [SerializeField] bool canScan = true;
    [SerializeField] bool canExtract = true;
    [SerializeField] bool isClicked = false;


    [Header("Tiles")]
    [SerializeField] int maxResourceTiles = 5;
    [SerializeField] int tileWidth = 20;
    [SerializeField] int tileHeight = 20;
    [SerializeField] GameObject tilePrefab = null;
    [SerializeField] GameObject firstTile = null;
    Tiles[,] grid;

    [Header("Text")]
    [SerializeField] Text infoText = null; 
    [SerializeField] Text scanText = null; 
    [SerializeField] Text extractText = null; 
    [SerializeField] Text resourceText = null; 

    // singleton
    public static miniGame instance;


    private void Awake()
    {
        instance = this;

        currentScanCount = maxScanCount;
        currentExtractCount = maxExtractCount;

        scanBtn.SetActive(false);
        extractBtn.SetActive(true);

        GenerateTileMap();

        GenerateRandomMaxResource();

        SetInfoText();
    }

    public void GenerateTileMap()
    {
        grid = new Tiles[tileRow, tileCol];

        for(int r = 0; r < tileRow; ++r)
        {
            for(int c = 0; c < tileCol; ++c)
            {
                GameObject tiles = Instantiate(tilePrefab, firstTile.transform);

                grid[r, c] = tiles.GetComponent<Tiles>();
                grid[r, c].SetGridIndices(r, c);
                grid[r, c].GetComponent<RectTransform>().localPosition = new Vector3((r * tileHeight) + (r * gridSpace), (c * tileWidth) + (c * gridSpace), 0);

            }
        }
    }

    public void GenerateRandomMaxResource()
    {
        for(int i = 0; i < maxResourceTiles; ++i)
        {

            int randomRow = Random.Range(0, tileRow);
            int randomCol = Random.Range(0, tileCol);
            Debug.Log(randomRow + " " +randomCol);
            // set max tile
            grid[randomRow, randomCol].IsMaxTile();
            grid[randomRow, randomCol].SetColor(Color.red);
            grid[randomRow, randomCol].SetResource();

            GenerateRandomNormalResources(randomRow, randomCol);
        }
    }


    ///   QQQQQ
    ///   QHHHQ
    ///   QHMHQ
    ///   QHHHQ
    ///   QQQQQ  if M = 0,0 -> First Q is -2, 2
    ///   Row = -2 -1 0 1 2
    ///   quater = row = -2 or 2/ col = -2 or 2


    public void GenerateRandomNormalResources(int maxRow, int maxCol)
    {
        for (int r = maxRow - 2; r < maxRow + 3; ++r)
        {
            // need to check if tile is null
            if (r < 0 || r > tileRow - 1)
            {
                continue;
            }

            for (int c = maxCol - 2; c < maxCol + 3; ++c)
            {
                // need to check if tile is null
                if (c < 0 || c > tileCol - 1)
                {
                    continue;
                }

                // Quater
                if (r == maxRow - 2 || r == maxRow +2 || c == maxCol -2 || c == maxCol + 2)
                {
                    grid[r, c].IsQuaterTile();
                    grid[r, c].SetColor(Color.green);
                    grid[r, c].SetResource();
                }
                //half
                else if (r == maxRow - 1 || r == maxRow + 1 || c == maxCol - 1 || c == maxCol + 1)
                {
                    grid[r, c].IsHalfTile();
                    grid[r, c].SetColor(Color.yellow);
                    grid[r, c].SetResource();
                }

            }
        }
    }

    public void ScanMode(int _tileRow, int _tileCol)
    {
        if (canScan)
        {
            currentScanCount--;
            SetScanText();

            if (currentScanCount < 0)
            {
                // cannot scan anymore.
                canScan = false;
                currentScanCount = 0;
                infoText.text = "CANNOT SCAN ANYMORE!";
                return;
            }


            for (int r = _tileRow - 1; r < _tileRow + 2; ++r)
            {
                // need to check if tile is null
                if (r < 0 || r > this.tileRow - 1)
                {
                    continue;
                }

                for (int c = _tileCol - 1; c < _tileCol + 2; ++c)
                {
                    // need to check if tile is null
                    if (c < 0 || c > this.tileCol - 1)
                    {
                        continue;
                    }

                    grid[r, c].OpenTileColor();

                }
            }
        }
    }

    public void ExtractMode(int _tileRow, int _tileCol)
    {
        if (canExtract)
         {
            currentExtractCount--;
            SetExtractText();
            if (currentExtractCount < 0)
            {
                // cannot scan anymore.
                canExtract = false;
                infoText.text = "CANNOT EXTRACT ANYMORE! GameOver!" ;
                return;
            }

            for (int r = _tileRow - 2; r < _tileRow + 3; ++r)
            {
                // need to check if tile is null
                if (r < 0 || r > this.tileRow - 1)
                {
                    continue;
                }

                for (int c = _tileCol - 2; c < _tileCol + 3; ++c)
                {
                    // need to check if tile is null
                    if (c < 0 || c > this.tileCol - 1)
                    {
                        continue;
                    }

                    grid[r, c].ExtractTile();
                    grid[_tileRow, _tileCol].SetColor(Color.white);
                    grid[r, c].OpenTileColor();

                    currentResourceCount += grid[r, c].GetResources();
                    resourceText.text = "Current Resources: " + currentResourceCount.ToString();
                }
            }
        }
    }


    public void GoExtract()
    {
        scanBtn.SetActive(false);
        extractBtn.SetActive(true);
        currentMode = MODE.EXTRACT;
    }

    public void GoScan()
    {
        scanBtn.SetActive(true);
        extractBtn.SetActive(false);
        currentMode = MODE.SCAN;
    }

    public void SetScanText()
    {
        if (scanText == null) return;
        else
        {
            scanText.text = "SCAN: " + currentScanCount.ToString() + " / " + maxScanCount.ToString();
            if(currentScanCount < 0)
            {
                scanText.text = "SCAN: 0 / " + maxScanCount.ToString();
            }
        }
    }
    public void SetExtractText()
    {
        if (extractText == null) return;
        else
        {
            extractText.text = "EXTRACT: " + currentExtractCount.ToString() + " / " + maxExtractCount.ToString();
            if (currentExtractCount < 0)
            {
                extractText.text = "EXTRACT: 0 / " + maxExtractCount.ToString();
            }
        }
    }

    public void SetInfoText()
    {
        if (infoText == null) return;
        else
        {
            infoText.text = "Welcome!! I am junhoKim, 101136986!";
        }
    }
    
}
