using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEditor;

public class GameOverscreen : MonoBehaviour
{
    public Text pointsText;
    [SerializeField] player_movement playerMovement;

    
  
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Setup( )
    {
        
        gameObject.SetActive(true);
         

    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
