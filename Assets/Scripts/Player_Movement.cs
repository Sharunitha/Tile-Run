using System;
using System.Collections;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class player_movement : MonoBehaviour
{

    bool alive=true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;


    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    public GameOverscreen GameOverscreen;
    public GameObject playerObject;
    public bool isGrounded;
   
   


    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float height = GetComponent<Collider>().bounds.size.y;
        isGrounded =Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

          if (isGrounded && Input.GetKeyDown(KeyCode.Space))
         {

            playerObject.GetComponent<Animator>().Play("Jump");
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        
        }
         if(isGrounded && Mathf.Abs(GetComponent<Rigidbody>().velocity.y) < 0.1f)
        {
            playerObject.GetComponent<Animator>().Play("Running");
        }
     

            if (transform.position.y < -5)
        {
            Die();
        }
    }
    public void Die()
    {
        alive = false;
        GameOver();
       
    }
 

   
    public void GameOver()
    {
        GameOverscreen.Setup();
        FindObjectOfType<AudioManager>().PlaySound("GameOver");
       

    }
}
