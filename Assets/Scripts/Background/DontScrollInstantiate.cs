using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontScrollInstantiate : MonoBehaviour
{
    public float spawnX = 0.0f; 
    public float spawnThreshold = 0.5f;
    public float incrementDistance = 10;
    public GameObject background;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(background, new Vector2 (spawnX, 0), transform.rotation );
    
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= spawnThreshold) {
            Instantiate(background, new Vector2 (spawnX, 0), transform.rotation );
                spawnThreshold += incrementDistance;
                spawnX += incrementDistance;

        }
    }

    
}
