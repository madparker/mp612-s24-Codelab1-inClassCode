using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    GameObject[,] level;    //2d Array that holds all our tiles
    GameObject levelHolder; //gameObject that acts as a folder for tiles in the Unity GUI

    public int levelWidth; //The width of the level being generated
    public int levelHeight; //The height of the level being generated

    int levelXOffset; //shift the position of the tiles on the x axis
    int levelYOffset; //shift the position of the tiles on the y axis

    //prefabs for the tiles
    public GameObject blankTile;
    public GameObject blueTile;
    public GameObject greenTile;

    public static LevelManager instance;  //singleton

    string FILE_PATH;
    const string FILE_DIR = "/Data/";
    public string fileName = "level.txt";

    public TMP_InputField inputField;
    
    void Awake()
    {
        //singleton code
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        inputField.text = fileName;
        
        levelHolder = new GameObject("Level");
        
        //set offsets based on width & height
        levelXOffset = -levelWidth / 2;
        levelYOffset = -levelHeight / 2;

        level = new GameObject[levelWidth, levelHeight]; //set the size of our 2D array

        //loop through every slot in our 2d array/grid
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelHeight; y++)
            {
                level[x, y] = Instantiate<GameObject>(blankTile);
                level[x, y].transform.parent = levelHolder.transform;
                level[x, y].transform.position = new Vector2(x, y);
                level[x, y].GetComponent<TileController>().isPlaced = true;
            }
        }

        //positioning the levelholder with the offsets
        levelHolder.transform.position = new Vector2(levelXOffset, levelYOffset);
    }

    public void SaveToFile()
    {
        fileName = inputField.text; //set the fileName to the current inputField value
        FILE_PATH = Application.dataPath + FILE_DIR + fileName;
        string asciiLevel = PrintLevel();
        Debug.Log(asciiLevel);
        File.WriteAllText(FILE_PATH, asciiLevel);
    }

    public void LoadFile()
    {
        Destroy(levelHolder);
        levelHolder = new GameObject("Level");
        
        //set offsets based on width & height
        levelXOffset = -levelWidth / 2;
        levelYOffset = -levelHeight / 2;

        level = new GameObject[levelWidth, levelHeight]; //set the size of our 2D array

        fileName = inputField.text;
        FILE_PATH = Application.dataPath + FILE_DIR + fileName;
        string[] lines = File.ReadAllLines(FILE_PATH);
        
        //loop through every slot in our 2d array/grid
        for (int y = 0; y < levelHeight; y++)
        {
            string line = lines[levelHeight - y - 1];
            char[] chars = line.ToCharArray();
            
            for (int x = 0; x < levelWidth; x++)
            {
                int num = Int32.Parse(chars[x] + "");

                switch (num)
                {
                   case 0:
                       level[x, y] = Instantiate<GameObject>(blankTile);
                       break;
                   case 1:
                       level[x, y] = Instantiate<GameObject>(blueTile);
                       break;
                   case 2:
                       level[x, y] = Instantiate<GameObject>(greenTile);
                       break;
                }
                level[x, y].transform.parent = levelHolder.transform;
                level[x, y].transform.position = new Vector2(x, y);
                level[x, y].GetComponent<TileController>().isPlaced = true;
            }
        }

        //positioning the levelholder with the offsets
        levelHolder.transform.position = new Vector2(levelXOffset, levelYOffset);

    }

    string PrintLevel()
    {
        string result = "";
        
        for (int y = levelHeight - 1 ; y >= 0; y--)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                result += level[x, y].GetComponent<TileController>().type;
            }

            result += "\n";
        }

        return result;
    }

    public void PlaceTile(GameObject tile)
    {
        //round down to an int position
        int x = Mathf.FloorToInt(tile.transform.position.x);
        int y = Mathf.FloorToInt(tile.transform.position.y);

        x -= levelXOffset;
        y -= levelYOffset;

        Debug.Log("Tile Pos: "+ x + "x" + y);

        //check to make sure the tile is in a valid grid position
        if (x >= 0 && x < levelWidth &&
            y >= 0 && y < levelHeight)
        {
            //if there's already a tile there
            if (level[x, y] != null)
            {
                Destroy(level[x, y]); //destroy existing tile
            }

            level[x, y] = tile; //place the new tile in that grid position
            
            CreateTile(tile.GetComponent<TileController>().type);
        }
        else
        {
            Destroy(tile); //destroy the tile if it's not at a valid grid location
        }
    }

    public void CreateTile(int tileNum)
    {
        GameObject tile = null;
        
        switch (tileNum)
        {
            case 0:
                tile = Instantiate<GameObject>(blankTile);
                break;
            case 1:
                tile = Instantiate<GameObject>(blueTile);
                break;
            case 2:
                tile = Instantiate<GameObject>(greenTile);
                break;
            default:
                break;
        }

        if (tile != null)
        {
            tile.transform.parent = levelHolder.transform;
        }
    }
}
