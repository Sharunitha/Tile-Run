using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        //check that the object we collided with this player
        if(other.gameObject.name != "Player")
        {
           
            return;
        }
        //Add to the player's score
        FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");


        GameManager.inst.IncrementScore();

            //destroy this coin object
            Destroy(gameObject);

        
       
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed * Time.deltaTime);
    }
}
