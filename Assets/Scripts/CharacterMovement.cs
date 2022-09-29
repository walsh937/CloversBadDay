using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D controller;
    public float CharacterMovementSpeed = 0.5f;
    public float MovementBoundary = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 charForce = new Vector2(Input.GetAxis("Horizontal") * CharacterMovementSpeed, Input.GetAxis("Vertical") * CharacterMovementSpeed);

        controller.AddForce(charForce * Time.deltaTime);
        //Bound movement on screen
        if (transform.position.y <= -MovementBoundary)
        {
            transform.position = new Vector2(transform.position.x, -MovementBoundary);
        }
        else if (transform.position.y >= MovementBoundary)
        {
            transform.position = new Vector2(transform.position.x, MovementBoundary);
        }
    }
}