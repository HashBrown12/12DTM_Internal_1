using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float movementSpeed = 8.0f;
    public float jumpForce = 7.0f;
    public float xBoundary = 25.0f;
    public bool isOnGround = true;
    public bool gameOver;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // code that recieves horizontal inputs and moves the player accordingly
        horizontalInput = Input.GetAxis("Horizontal");
        // Vector 3 forward is used here because I had to rotate the player model
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * movementSpeed);

        // if statement to make the player jump when input is recieved
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        // if statement to set a boundary on the left
        if (transform.position.x < -xBoundary)
        {
            transform.position = new Vector3(-xBoundary, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        } 
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            gameManager.GameOver();
        }
    }
    // this function destroys the bananas when the player collides with them
    // and adds 5 to the score count.
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(5);
        }
    }
}
