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
        display.text = "Score: " + score + "\nTime:" + (maxTime - (int)timer);

        //add the fraction of a second between frames to timer
        timer += Time.deltaTime;
        
        //if timer is >= maxTime
        if (timer >= maxTime && isInGame)
        {
            isInGame = false;
            SceneManager.LoadScene("EndScene");
        }
    }
}
