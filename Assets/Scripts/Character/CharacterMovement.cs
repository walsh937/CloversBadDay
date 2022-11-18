using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D controller;
    private SpriteRenderer sr;
    public GameObject characterShadow;
    public float CharacterMovementSpeed = 0.5f;
    public float MovementBoundary = 3.0f;
    

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private IEnumerator jump()
    {
        float y_velocity = 10;
        float x_velocity = controller.velocity.x;
        while (y_velocity > -10)
        {
            controller.velocity = new Vector2(x_velocity, y_velocity);
            y_velocity -= 0.5f * Time.deltaTime * 60;
            print(controller.velocity);
            yield return new WaitForSecondsRealtime(0.001f); //Wait 1 second
        }
        characterShadow.GetComponent<CharacterShadow>().SetShadow(true);
        
            
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKey("space"))
        {
            //print(GameObject.Find("Heroine").GetComponent<PlayerData>().walk_speed);
            characterShadow.GetComponent<CharacterShadow>().SetShadow(false);
            StartCoroutine("jump");
        }

        if(Input.GetKeyDown("space")) {
            GameObject.Find("Heroine").GetComponent<PlayerData>().score -= 5;
        }

        Vector3 charForce = new Vector2(Input.GetAxis("Horizontal") * CharacterMovementSpeed, Input.GetAxis("Vertical") * CharacterMovementSpeed);
        if (charForce.x < 0)
        {
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }
        
        //GameObject.Find("Heroine").GetComponent<PlayerData>().distance += Input.GetAxis("Horizontal");
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