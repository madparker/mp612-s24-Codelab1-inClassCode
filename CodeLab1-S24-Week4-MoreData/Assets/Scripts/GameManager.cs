using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI display;
    
    public int score;

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
                
            }
        }

    }
    
    List<int> highScores;

    public List<int> HighScores
    {
        get
        {
            if (highScores == null)
            {
                highScores = new List<int>();
                
                highScores.Add(0);
                highScores.Insert(0, 3);
                highScores.Insert(1, 2);
                highScores.Insert(2, 1);
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
            display.text = "GAME OVER\nFINAL SCORE: " + score;
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
