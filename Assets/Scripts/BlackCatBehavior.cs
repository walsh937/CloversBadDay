using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatBehavior : MonoBehaviour
{
    public float catSpeed = 1;
    public float scrollSpeed = 0.5f;

    public GameObject pawprint;
    public GameObject PawprintSpawner;
    public float correctionDistance;

    private string catState = "walk";
    private float timeSinceDirectionUpdate = 0;
    private float timeSincePawprint = 0; 
    private float timeToUpdate = 2f;
    private float pawprintOffset = 1f;

    private Quaternion newRotation;
    private Vector3 directionToMove = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }
    void ChangeDirection()
    {
        timeSinceDirectionUpdate = 0;
        timeToUpdate = Random.Range(2, 5);
        if (transform.position.y < -correctionDistance) {
            newRotation = Quaternion.Euler(0, 0, Random.Range(45, 134));
        } else if (transform.position.y > correctionDistance) {
            newRotation = Quaternion.Euler(0, 0, Random.Range(225, 314));
        } else {
            newRotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
        }
            
        catState = "turn";
    }
    void Walk()
    {
        directionToMove = new Vector2(catSpeed, 0);
        transform.Translate(directionToMove * Time.deltaTime);
        transform.Translate(new Vector2(-scrollSpeed * Time.deltaTime, 0), Space.World);
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceDirectionUpdate += Time.deltaTime;
        timeSincePawprint += Time.deltaTime;
        if (catState == "walk")
        {
            Walk();
            if (timeSinceDirectionUpdate > timeToUpdate) //randomly change direction
            {
                ChangeDirection();
            }
        }
        else if (catState == "turn")
        {
            Walk();
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.05f);

            if (timeSinceDirectionUpdate > 1)
            {
                catState = "walk";
            }
        }

        //pawprint spawner
        if (timeSincePawprint > 0.3f) {
            PawprintSpawner.transform.localPosition = new Vector2(0, pawprintOffset);
            Vector3 spawnPosition = PawprintSpawner.transform.position;
            Instantiate(pawprint, spawnPosition, transform.rotation);
            pawprintOffset *= -1;
            timeSincePawprint = 0;

            if (transform.position.x < -11.5f) {
                Object.Destroy(gameObject);
            }
        }

        //rotation animation control
    }
}
