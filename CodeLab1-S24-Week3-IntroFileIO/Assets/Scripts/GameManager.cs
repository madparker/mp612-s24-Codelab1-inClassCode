using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int score = 0;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
             score = value;
             Debug.Log("score changed!");

             if (score > HighScore)
             {
                 HighScore = score;
             }
        }
    }

    int highScore = 0;

    const string KEY_HIGH_SCORE = "High Score";
    
    int HighScore
    {
        get
        {
            //highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);

            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);
                highScore = Int32.Parse(fileContents);
            }

            return highScore;
        }
        
        set
        {
            highScore = value;
            Debug.Log("New High Score!!!");
            //PlayerPrefs.SetInt(KEY_HIGH_SCORE, highScore);
            string fileContent = "" + highScore;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }

            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
        }
    }

    public int targetScore = 3;
    
    public TextMeshProUGUI scoreText;

    int levelNum = 1;

    const string DATA_DIR = "/Data/";
    const string DATA_HS_FILE = "hs.txt";

    string DATA_FULL_HS_FILE_PATH;
    
    void Awake()
    {
        if (instance == null) //if the instance var has not been set
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //if there is already a singleton of this type
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteKey(KEY_HIGH_SCORE);
        }

        scoreText.text = "Level: " + levelNum + "\nScore: " + score + "\nHigh Score: " + HighScore;
        
        //when score reaches target score, we go to the next level
        if (score == targetScore)
        {
            levelNum++;
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1);
            targetScore = Mathf.RoundToInt(targetScore + targetScore * 1.5f);
        }
    }
}
