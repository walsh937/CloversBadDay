using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject bg;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        bg.GetComponent<SpriteRenderer>().enabled = false;
        text.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame

    public void OnDeath()
    {
        bg.GetComponent<SpriteRenderer>().enabled = true;
        text.GetComponent<SpriteRenderer>().enabled = true;
    }
}
