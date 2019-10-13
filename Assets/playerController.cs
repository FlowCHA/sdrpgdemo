using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //take input on the arrow key presses
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //build a vector3 (three directions) of both inputs, leaving 0 for z because it's a 2D game
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        //normalize the vector and apply speed to it for movement calculation
        //Time.deltaTime addresses latency issues should a computer run slowly, or multiplayer is integrated
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;
        //move rigidbody and object for collision detection in the future
        myRigidBody.MovePosition(myRigidBody.transform.position + moveDirection);

    }

    //below code will be moved to a separate script and also updated for future versions
    //current code is bad because it detects any object tagged Door and does not associate with scenes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when the player connects with an object with a tag of "Door",
        if(collision.tag == "Door")
        {
            //load the scene named LevelTwo
            SceneManager.LoadScene("LevelTwo");
            if(SceneManager.GetActiveScene().name == "LevelOne")
                SceneManager.LoadScene("LevelTwo");
            if (SceneManager.GetActiveScene().name == "LevelTwo")
            {
                SceneManager.LoadScene("LevelOne");
            }
        }
    }
}
