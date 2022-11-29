using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSpawner2 : MonoBehaviour
{
    
    Vector2 spawnLocation;
    Vector3 spawnRotation;

    float timer = 4;
    public GameObject[] prefabs;
    public float crackCooldown = 1;
    public float scrollSpeed = 4;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > crackCooldown) {
            timer = 0;
            int spawnCount = (int)Random.Range(1.5f, 4.5f);
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject crackPrefab = prefabs[(int)Random.Range(0.0f, 5.999f)];
                spawnLocation = new Vector2(GameObject.Find("Heroine").transform.position.x+Random.Range(20f, 24f), Random.Range(1, -6));
                spawnRotation = new Vector3(0, 0, 0);
                GameObject crackInst = Instantiate(crackPrefab, spawnLocation, Quaternion.identity);
                crackInst.GetComponent<CrackMovement>().CrackStart(scrollSpeed, player);
            }
        }
    }
}
