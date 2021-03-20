using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] int gridRow = 0;
    [SerializeField] int gridColonm = 0;

    // 2d grid
    private MatchTiles[,] grid;

    [Header("Tile")]
    [SerializeField] GameObject tilePrefab = null;
    [SerializeField] int tileWidth = 20;
    [SerializeField] int tileHeight = 20;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        grid = new MatchTiles[gridRow, gridColonm];

        for(int r = 0; r < gridRow; ++r)
        {
            for(int c = 0; c < gridColonm; ++c)
            {
                GameObject tiles = Instantiate(tilePrefab, transform);
                grid[r, c] = tiles.GetComponent<MatchTiles>();
                grid[r, c].SetGridIndices(r, c);
                grid[r, c].GetComponent<RectTransform>().localPosition = new Vector3(r * tileHeight, c * tileWidth, 0);
            }
        }
    }
}
