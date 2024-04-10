using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int gridWidth = 2;
    public int gridHeight = 2;

    public GameObject[,] grid;

    public GameObject prefab;

    public static Grid instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[gridWidth, gridHeight];
        
        //fill the grid with prefabs that appear in the corresponding
        //position they occupy in the grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = Instantiate<GameObject>(prefab);
                grid[x, y].transform.position = new Vector2(x, y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        string gridRepresentation = "";

        for (int y = 0; y < gridHeight; y++)
        {
            gridRepresentation += "\n";
            for (int x = 0; x < gridWidth; x++)
            {
                if (grid[x, y] != null)
                {
                    gridRepresentation += "0";
                }
                else
                {
                    gridRepresentation += "_";
                }
            }
        }
        
        Debug.Log(gridRepresentation);
    }
}
