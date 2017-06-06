using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------------------------------------ 
// Author:  Joseph Garrity 
// Date:    05-22-2017 
// Credit:  Programming Foundations 2 course
// Credit:  Jumping Script Torurial by N3K EN Link: https://www.youtube.com/watch?v=miMCu5796KM&t=174s
// Purpose: 
//------------------------------------------------------------------------------------------------ 

public class JGG_PlayerController : MonoBehaviour {
    [SerializeField]
    float speedForce = 5.0f;

    [SerializeField]
    float jumpVelocity = 10.0f;

    [SerializeField]
    float gForce = 2.0f;

    public float jumpforce;

    private Vector3 move = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumpforce = jumpVelocity;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpforce -= gForce * Time.deltaTime;
        }
        else if (jumpforce == 0.0f)
        {
                jumpforce = 0.0f;
        }

        UpdateMovement();
    }

    private void UpdateMovement()
    {
        //Move the player laterally in the 'X' coordinate
        move.x = Input.GetAxis("Horizontal") * Time.deltaTime * speedForce;

        //Move the player laterally in the 'Y' coordinate
        move.y = Input.GetAxis("Vertical") * Time.deltaTime * jumpforce;

        //Apply the movement vector to the game object's position
        gameObject.transform.Translate(move);
    }
}
