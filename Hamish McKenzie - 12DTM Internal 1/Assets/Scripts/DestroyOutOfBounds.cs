using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // variables
    private float yBoundary = 7;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        // an if statement which destroys the obstacles
        // once they reach a certain y position
        if(transform.position.y < -yBoundary)
        {
            Destroy(gameObject);

        }
    }
}
