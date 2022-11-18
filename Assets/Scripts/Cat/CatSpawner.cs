using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject BlackCat;
    public GameObject mainCamera;
    float timer = 0;
    public float catSpawnCooldown = 15.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3 (mainCamera.transform.position.x, 0, 0);
        timer += Time.deltaTime;
        if (timer > catSpawnCooldown)
        {
            timer = 0;
            if (catSpawnCooldown > 2) {
                catSpawnCooldown *= 0.85f;
            }
            Instantiate(BlackCat, new Vector3(mainCamera.transform.position.x+15, 0, 0), transform.rotation);
        }
    }
}
