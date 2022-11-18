using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatBehavior : MonoBehaviour
{
    public float catSpeed = 1;
    public float scrollSpeed = 0.5f;

    public GameObject pawprint;
    public GameObject PawprintSpawner;
    public GameObject mainCamera;
    public float correctionDistance;
    public bool pathCrossed = false;

    private string catState = "walk";
    private float timeSinceDirectionUpdate = 2;
    private float timeSincePawprint = 0; 
    private float timeToUpdate = 2f;
    private float pawprintOffset = 1f;

    private Quaternion newRotation;
    private Vector3 directionToMove = new Vector3(0, 0, 0);
    private GameObject BlackCatSprite;
    private GameObject player;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        BlackCatSprite = GameObject.Find("kittySprite");
        player = GameObject.Find("Heroine");
        mainCamera = GameObject.Find("Main Camera");
    }
    private void ChangeDirection()
    {
        timeSinceDirectionUpdate = 0;
        timeToUpdate = Random.Range(2, 5);
        if (transform.position.y < -3) {
            newRotation = Quaternion.Euler(0, 0, Random.Range(45, 134));
        } else if (transform.position.y > 1) {
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
        if (transform.position.x < -11.5f + mainCamera.transform.position.x)
        {
            Object.Destroy(transform.parent.gameObject);
        }
        timeSinceDirectionUpdate += Time.deltaTime;
        timeSincePawprint += Time.deltaTime;
        Walk();
        if (timeSinceDirectionUpdate > 0.3 && transform.position.y > 1)
        {
            ChangeDirection();
        }
        if (catState == "walk")
        {
            if (timeSinceDirectionUpdate > timeToUpdate) //randomly change direction
            {
                ChangeDirection();
            }
        }
        else if (catState == "turn")
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 0.05f);

            if (timeSinceDirectionUpdate > 1)
            {
                catState = "walk";
            }
        }

        //pawprint spawner
        if (timeSincePawprint > 0.3f) {
            PawprintSpawner.transform.localPosition = new Vector2(0, pawprintOffset);
            Vector3 spawnPosition = PawprintSpawner.transform.position - new Vector3(0, 0.8f, 0);
            GameObject newPawprint = Instantiate(pawprint, spawnPosition, transform.rotation);
            newPawprint.GetComponent<PawprintMovement>().PawprintStart(scrollSpeed, this, player, mainCamera);
            pawprintOffset *= -1;
            timeSincePawprint = 0;

        }
        // render ordering
        if (BlackCatSprite != null)
        {
            if (player.transform.position.y - 1 > transform.position.y)
            {
                BlackCatSprite.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            else
            {
                BlackCatSprite.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
        }

        //rotation animation control
        Vector3 rot = transform.rotation.eulerAngles;
        float rot_multiplier = 45;
        if (rot.z < Mathf.PI/4)
        {
            animator.SetInteger("direction", 0);
        }
        else if (rot.z < 2 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 1);
        }
        else if (rot.z < 3 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 2);
        }
        else if (rot.z < 4 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 3);
        }
        else if (rot.z < 5 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 4);
        }
        else if (rot.z < 6 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 5);
        }
        else if (rot.z < 7 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 6);
        }
        else if (rot.z < 8 * rot_multiplier - 22.5)
        {
            animator.SetInteger("direction", 7);
        }
        else
        {
            animator.SetInteger("direction", 0);
        }

    }
}
