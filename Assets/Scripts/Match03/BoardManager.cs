using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour
{
	// singleton
	public static BoardManager instance;

	// list that contain all tile characters
	public List<Sprite> characters = new List<Sprite>();

	// actual tile prefab
	public GameObject tile;

	// grid size
	public int xSize, ySize;

	// 2d grid
	private GameObject[,] tiles;

	// boolean
	public bool IsShifting { get; set; }

	void Start()
	{
		instance = GetComponent<BoardManager>();

		Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
		CreateBoard(offset.x, offset.y);
	}

	private void CreateBoard(float xOffset, float yOffset)
	{
		tiles = new GameObject[xSize, ySize];

		float startX = transform.position.x;
		float startY = transform.position.y;

		for (int x = 0; x < xSize; x++)
		{
			for (int y = 0; y < ySize; y++)
			{
				GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
				tiles[x, y] = newTile;
			}
		}
	}

}

