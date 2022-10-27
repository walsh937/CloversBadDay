using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject BlackCat;
    float timer = 0;
    float catSpawnCooldown = 5.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > catSpawnCooldown)
        {
            timer = 0;
            catSpawnCooldown *= 0.85f;

            Instantiate(BlackCat, transform);
        }
    }
}
