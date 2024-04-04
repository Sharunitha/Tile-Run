using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Mainmenu : MonoBehaviour
{
   public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
