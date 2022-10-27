using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlackCatSprite : MonoBehaviour
{
    public GameObject BlackCat;
    private SpriteRenderer SR;

    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (BlackCat == null)
        {
            Object.Destroy(this);
        }
        transform.position = BlackCat.transform.position;
        if (BlackCat.transform.rotation.eulerAngles.z > 90 + 22.5 && BlackCat.transform.rotation.eulerAngles.z < 270 - 22.5) {
            SR.flipX = true;
        } else {
            SR.flipX = false;
        }
    }
}
