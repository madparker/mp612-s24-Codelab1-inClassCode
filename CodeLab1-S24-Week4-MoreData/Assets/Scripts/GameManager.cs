using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI display;
    
    public int score;
    
    const string FILE_DIR = "/DATA/";
    const string DATA_FILE = "highScores.txt";
    string FILE_FULL_PATH;
    
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;

            if (isHighScore(score))
            {
                int highScoreSlot = -1;

                for (int i = 0; i < HighScores.Count; i++)
                {
                    if (score > highScores[i])
                    {
                        highScoreSlot = i;
                        break;
                    }
                }
                
                highScores.Insert(highScoreSlot, score);

                highScores = highScores.GetRange(0, 5);

                string scoreBoardText = "";

                foreach (var highScore in highScores)
                {
                    scoreBoardText += highScore + "\n";
                }

                highScoresString = scoreBoardText;
                
                File.WriteAllText(FILE_FULL_PATH, highScoresString);
            }
        }

    }

    string highScoresString = "";
    
    List<int> highScores;

    public List<int> HighScores
    {
        get
        {
            if (highScores == null)
            {
                highScores = new List<int>();

                highScoresString = File.ReadAllText(FILE_FULL_PATH);

                highScoresString = highScoresString.Trim();
                
                string[] highScoreArray = highScoresString.Split("\n");

                for (int i = 0; i < highScoreArray.Length; i++)
                {
                    int currentScore = Int32.Parse(highScoreArray[i]);
                    highScores.Add(currentScore);
                }
            }

            return highScores;
        }
    }

    float timer = 0;

    public int maxTime = 10;

    bool isInGame = true;
    
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
        FILE_FULL_PATH = Application.dataPath + FILE_DIR + DATA_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame)
        {
            display.text = "Score: " + score + "\nTime:" + (maxTime - (int)timer);
        }
        else
        {
            display.text = "GAME OVER\nFINAL SCORE: " + score +
                           "\nHigh Scores:\n" + highScoresString;
        }

        //add the fraction of a second between frames to timer
        timer += Time.deltaTime;
        
        //if timer is >= maxTime
        if (timer >= maxTime && isInGame)
        {
            isInGame = false;
            SceneManager.LoadScene("EndScene");
        }
    }

    bool isHighScore(int score)
    {

        for (int i = 0; i < HighScores.Count; i++)
        {
            if (highScores[i] < score)
            {
                return true;
            }
        }

        return false;
    }
}
