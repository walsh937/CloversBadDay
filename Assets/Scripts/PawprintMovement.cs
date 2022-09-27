using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawprintMovement : MonoBehaviour
{
    public GameObject self;
    public float scrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x < -10.6f)
        {
            Object.Destroy(self);
        }
    }
}
