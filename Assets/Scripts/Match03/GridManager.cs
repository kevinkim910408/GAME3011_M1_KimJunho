using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid")]
    [SerializeField] int gridRow;
    [SerializeField] int gridColonm;

    // 2d grid
    private MatchTiles[,] grid;

    [Header("Tile")]
    [SerializeField] GameObject tilePrefab = null;
    [SerializeField] int tileWidth;
    [SerializeField] int tileHeight;


    // Start is called before the first frame update
    void Start()
    {

        // generate grid
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        // set grid
        grid = new MatchTiles[gridRow, gridColonm];

        // place tiles
        for(int r = 0; r < gridRow; ++r)
        {
            for(int c = 0; c < gridColonm; ++c)
            {
                GameObject tiles = Instantiate(tilePrefab, transform);

                grid[r, c] = tiles.GetComponent<MatchTiles>();
                
                // give grid indices
                grid[r, c].SetGridIndices(r, c);

                // tiles positions
                grid[r, c].GetComponent<RectTransform>().localPosition 
                    = new Vector3(r * tileHeight, c * tileWidth, 0);
            }
        }
    }
}
