using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] player_movement playerMovement;
    [SerializeField] GameOverscreen gameOverScreen;



    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        //increase the player's speed
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
       
    }
   


    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
   
}
