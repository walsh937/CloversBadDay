using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSpawner2 : MonoBehaviour
{
    
    Vector2 spawnLocation;
    Vector3 spawnRotation;

    float timer = 4;
    public float crackCooldown = 1;
    public GameObject crack;
    public float scrollSpeed = 4;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > crackCooldown) {
            timer = 0;
            int spawnCount = (int)Random.Range(1.5f, 4.5f);
            for (int i = 0; i < spawnCount; i++)
            {
                spawnLocation = new Vector2(GameObject.Find("Heroine").transform.position.x+14, Random.Range(1, -6));
                spawnRotation = new Vector3(0, 0, Random.Range(0, 359));
                GameObject crackInst = Instantiate(crack, spawnLocation, Quaternion.Euler(spawnRotation));
                crackInst.GetComponent<CrackMovement>().CrackStart(scrollSpeed, player);
            }
        }
    }
}
