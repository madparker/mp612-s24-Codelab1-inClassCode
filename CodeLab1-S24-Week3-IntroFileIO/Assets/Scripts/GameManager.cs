using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;

    public int targetScore = 3;
    
    public TextMeshProUGUI scoreText;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        
        //when score reaches target score, we go to the next level
        if (score == targetScore)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1);
            targetScore = Mathf.RoundToInt(targetScore + targetScore * 1.5f);
        }
    }
}
