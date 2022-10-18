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
    private Animation anim;
    private GameObject BlackCatSprite;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animation>();
        BlackCatSprite = GameObject.Find("kittySprite");
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
            Vector3 spawnPosition = PawprintSpawner.transform.position - new Vector3(0, 0.8f, 0);
            Instantiate(pawprint, spawnPosition, transform.rotation);
            pawprintOffset *= -1;
            timeSincePawprint = 0;

            if (transform.position.x < -11.5f) {
                Object.Destroy(BlackCatSprite);
                Object.Destroy(gameObject);
            }
        }

        //rotation animation control
        Vector3 rot = transform.rotation.eulerAngles;
        float rot_multiplier = 45;
        Debug.Log(rot);
        if (rot.z < Mathf.PI/4)
        {
            Debug.Log("anim1");
            anim.Play("WALK_E");
            animator.SetInteger("direction", 0);
        }
        else if (rot.z < 2 * rot_multiplier - 22.5)
        {
            Debug.Log("anim2");
            animator.SetInteger("direction", 1);
        }
        else if (rot.z < 3 * rot_multiplier - 22.5)
        {
            Debug.Log("anim3");
            animator.SetInteger("direction", 2);
        }
        else if (rot.z < 4 * rot_multiplier - 22.5)
        {
            Debug.Log("anim4");
            animator.SetInteger("direction", 3);
        }
        else if (rot.z < 5 * rot_multiplier - 22.5)
        {
            Debug.Log("anim5");
            animator.SetInteger("direction", 4);
        }
        else if (rot.z < 6 * rot_multiplier - 22.5)
        {
            Debug.Log("anim6");
            animator.SetInteger("direction", 5);
        }
        else if (rot.z < 7 * rot_multiplier - 22.5)
        {
            Debug.Log("anim7");
            anim.Play("WALK_S");
            animator.SetInteger("direction", 6);
        }
        else if (rot.z < 8 * rot_multiplier - 22.5)
        {
            Debug.Log("anim8");
            animator.SetInteger("direction", 7);
        }
        else
        {
            Debug.Log("anim1");
            animator.SetInteger("direction", 0);
        }

    }
}
