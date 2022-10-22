using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D controller;
    public GameObject characterShadow;
    public float CharacterMovementSpeed = 0.5f;
    public float MovementBoundary = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }

    private IEnumerator jump()
    {
        float y_velocity = 10;
        float x_velocity = 10;
        while (y_velocity > -10)
        {
            controller.velocity = new Vector2(x_velocity, y_velocity);
            y_velocity -= 0.5f * Time.deltaTime * 60;
            print(controller.velocity);
            yield return new WaitForSecondsRealtime(0.001f); //Wait 1 second
        }
        characterShadow.GetComponent<CharacterShadow>().SetShadow(true);
        Debug.Log("Jumped");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            print(GameObject.Find("Heroine").GetComponent<PlayerData>().walk_speed);
            characterShadow.GetComponent<CharacterShadow>().SetShadow(false);
            StartCoroutine("jump");
        }

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