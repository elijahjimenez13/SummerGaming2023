using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] // This will attach a CharacterController component to the player automatically when this scrip is attached
public class PlayerController : MonoBehaviour
{
    // SerializeField lets you edit a private variable in the Unity Editor
    [SerializeField, Tooltip("How fast the player moves")]
    private float _moveSpeed = 5.0f;

    [SerializeField, Tooltip("The force that the player jumps with")]
    private float _jumpForce = 10.0f;

    [SerializeField, Tooltip("The force that the player is pulled back to the ground")]
    private float _gravity = 9.8f;

    [SerializeField, Tooltip("A reference to the CharacterController component on the player")]
    private CharacterController _pController;

    private Vector3 _moveDirection; // The curent direction the player is moving in // A Vector3 (x, y, z)

    // Start is called before the first frame update
    private void Start()
    {
        _pController = GetComponent<CharacterController>(); // Assigning this var to CharacterController on this, the player
    }

    // Update is called once per frame
    private void Update()
    {
        // Collect Player Input
        float _xInput = Input.GetAxis("Horizontal"); // Stores the Horizontal input of the player (left, right)
        float _zInput = Input.GetAxis("Vertical"); // Stores the Vertical input of the player (forward, back)

        // Apply Player movement based on Input
        Vector3 movement = new Vector3(_xInput, 0, _zInput); // Calculate direction of movement
        
        movement = transform.TransformDirection(movement) * _moveSpeed; // Converts Vector3 from local space to world space

        if (_pController.isGrounded) // If the player is on the ground...
        {
            _moveDirection = movement;

            if (Input.GetButton("Jump")) // If the player hits the space bar while grounded
            {
                // Make the player jump
                _moveDirection.y += _jumpForce;
            }
        } else // The player is in the air
        {
            // Pull the player back to the ground with gravity
            _moveDirection.y -= _gravity * Time.deltaTime;
        }

        _pController.Move(_moveDirection * Time.deltaTime); // The function call that moves the player based on _moveDirection
    }
}
