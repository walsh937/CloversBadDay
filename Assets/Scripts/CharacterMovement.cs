using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    public float CharacterMovementSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 charVelocity = new Vector3(0, Input.GetAxis("Vertical") * CharacterMovementSpeed, 0);

        controller.Move(charVelocity * Time.deltaTime);

    }
}
