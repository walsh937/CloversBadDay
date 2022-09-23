using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatBehavior : MonoBehaviour
{
    private float timeSinceDirectionUpdate = 0;
    float catSpeed = 1;
    private float timeToUpdate = 2f;
    private Vector3 eulerRotation;

    Vector3 directionToMove = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDirectionUpdate += Time.deltaTime;
        //update direction every x seconds
        if (timeSinceDirectionUpdate > timeToUpdate)
        {
            transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 359));
            timeSinceDirectionUpdate = 0;
            timeToUpdate = Random.Range(1, 5);
        }
        //calculate the forward direction manually cause idk how to get it from unity
        eulerRotation = transform.rotation.eulerAngles;
        directionToMove = new Vector3(Mathf.Cos(eulerRotation.x), -Mathf.Sin(eulerRotation.x));

        transform.Translate(directionToMove * Time.deltaTime * catSpeed);
    }
}
