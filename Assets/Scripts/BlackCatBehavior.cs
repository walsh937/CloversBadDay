using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCatBehavior : MonoBehaviour
{
    public float catSpeed = 1;
    public float scrollSpeed = 0.5f;

    public GameObject pawprint;

    private float timeSinceDirectionUpdate = 0;
    private float timeSincePawprint = 0; 
    private float timeToUpdate = 2f;
    private float pawprintOffset = 1f;

    Vector3 directionToMove = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceDirectionUpdate += Time.deltaTime;
        timeSincePawprint += Time.deltaTime;
        //update direction every x seconds
        if (timeSinceDirectionUpdate > timeToUpdate)
        {
            transform.rotation = Quaternion.Euler(0,0,Random.Range(0, 359));
            timeSinceDirectionUpdate = 0;
            timeToUpdate = Random.Range(2, 5);
        }

        if (timeSincePawprint > 0.3f){
            Vector3 spawnPosition = transform.TransformPoint(transform.localPosition.x-3, transform.localPosition.y + pawprintOffset-1, transform.localPosition.z);
            Instantiate(pawprint, spawnPosition, transform.rotation);
            pawprintOffset *= -1;
            timeSincePawprint = 0;
            Debug.Log(pawprintOffset);
        }

        //move cat
        directionToMove = new Vector2(catSpeed, 0);

        transform.Translate(directionToMove * Time.deltaTime);
        transform.Translate(new Vector2(-scrollSpeed * Time.deltaTime, 0), Space.World);
    }
}
