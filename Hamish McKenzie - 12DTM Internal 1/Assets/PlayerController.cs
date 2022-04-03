using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float movementSpeed = 10.0f;
    public float jumpForce = 5.0f;
    public float xBoundary = 10.6f;
    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // code that recieves horizontal inputs and moves the player accordingly
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

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
        isOnGround = true;
    }
}
