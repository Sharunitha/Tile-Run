using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Obstacle : MonoBehaviour
{
    player_movement playerMovement;
   private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<player_movement>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }


    void Update()
    {
        
    }
}
