using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float movementSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;

    Rigidbody2D rbody; 
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
    }


     //Update is called once per frame
    void FixedUpdate()
    {
        //current player position
        Vector2 currentPos = rbody.position;
        //getting the player's inputs
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        //generating the direction vector from input
        //we use an isometric grid where x = 2 * y
        //so to move the player diagonnally with the right angle 30°
        //we multiply the X by 2
        Vector2 inputVector = new Vector2(horizontalInput * 2, verticalInput);
        //clamping the vector to the movement speed to avoid abnormal speed up
        //in diagonal movement
        inputVector = Vector2.ClampMagnitude(inputVector, movementSpeed);
        //generating the movement vector
        Vector2 movement = inputVector * movementSpeed;
        //calculating the player's target position
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //vector without angle tweaking needed for calculating the index of the
        //animation to be selected in the renderer
        Vector2 animVect = new Vector2(horizontalInput, verticalInput);
        animVect = Vector2.ClampMagnitude(animVect, 1);
        //rendering the correct player animation
        isoRenderer.SetDirection(animVect * movementSpeed);
        //moving the player
        rbody.MovePosition(newPos);
    }
}
