using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    GameObject[,] level;
    GameObject levelHolder;

    public int levelWidth;
    public int levelHeight;

    int levelXOffset;
    int levelYOffset;

    public GameObject blankTile;
    public GameObject blueTile;
    public GameObject greenTile;

    public static LevelManager instance;

    // Start is called before the first frame update

    void Awake()
    {
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
        levelHolder = new GameObject("Level");
        
        levelXOffset = -levelWidth / 2;
        levelYOffset = -levelHeight / 2;

        level = new GameObject[levelWidth, levelHeight];

        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelWidth; y++)
            {
                level[x, y] = Instantiate<GameObject>(blankTile);
                level[x, y].transform.parent = levelHolder.transform;
                level[x, y].transform.position = new Vector2(x, y);
                level[x, y].GetComponent<TileController>().isPlaced = true;
            }
        }

        levelHolder.transform.position = new Vector2(levelXOffset, levelYOffset);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(PrintLevel());
        }
    }

    string PrintLevel()
    {
        string result = "";
        
        for (int x = 0; x < levelWidth; x++)
        {
            for (int y = 0; y < levelWidth; y++)
            {
                result += level[x, y].GetComponent<TileController>().type;
            }

            result += "\n";
        }

        return result;
    }

    public void PlaceTile(GameObject tile)
    {
        int x = Mathf.FloorToInt(tile.transform.position.x);
        int y = Mathf.FloorToInt(tile.transform.position.y);

        x -= levelXOffset;
        y -= levelYOffset;

        Debug.Log("Tile Pos: "+ x + "x" + y);
        
        if (level[x, y] != null)
        {
            Destroy(level[x, y]);
        }

        level[x, y] = tile;
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
