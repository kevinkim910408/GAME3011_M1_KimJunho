using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTiles : MonoBehaviour
{
    [Header("Tiles")]
    [SerializeField] int row, col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGridIndices(int r, int c)
    {
        row = r;
        col = c;
    }
}
