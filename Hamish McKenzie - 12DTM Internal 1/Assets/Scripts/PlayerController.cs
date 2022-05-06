using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables
    private Rigidbody playerRb;
    public float horizontalInput;
    public float movementSpeed = 8.0f;
    public float jumpForce = 7.0f;
    public float xBoundaryLeft = 25.0f;
    public float xBoundaryRight = 80.0f;
    public float yBoundary = 7.0f;
    public bool isOnGround = true;
    public bool gameOver;
    public bool youWin;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        // Getting the component for the player rigidbody
        playerRb = GetComponent<Rigidbody>();
        // importing the GameManager script so that this script
        // can communicate with it and make texts appear
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
        if (transform.position.x < -xBoundaryLeft)
        {
            transform.position = new Vector3(-xBoundaryLeft, transform.position.y, transform.position.z);
        }
        // if statement to set a boundary on the right
        if(transform.position.x > xBoundaryRight)
        {
            transform.position = new Vector3(xBoundaryRight, transform.position.y, transform.position.z);
        }
        // if statement to display the Game Over message when the player
        // falls down far enough
        if(transform.position.y < -yBoundary)
        {
            Debug.Log("Game Over");
            gameOver = true;
            gameManager.GameOver();
        }
        // if statement to disable the script if the gameOver = true
        // so that the player can't continue the game
        if(gameOver == true)
        {
            enabled = false;
        }
        // if statement to disable the script if the youWin = true
        // so that the player can't continue to play.
        if(youWin == true)
        {
            enabled = false;
        }
    }
    // a function which deals with all of the collisions in the
    // game and enables texts e.g winning text and losing text
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
        else if(collision.gameObject.CompareTag("EndGoal"))
        {
            Debug.Log("You Win!");
            gameManager.YouWin();
            youWin = true;

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
