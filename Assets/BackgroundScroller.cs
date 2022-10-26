using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2;
    public GameObject background;
    private GameObject firstBackground;
    private Transform spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = transform;
        firstBackground = Instantiate(background, spawnpoint);
        firstBackground.GetComponent<BGIndividualScroll>().scrollSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstBackground == null || firstBackground.transform.position.x < 0)
        {
            Debug.Log(firstBackground.transform.position + " " + spawnpoint.position);
            firstBackground = Instantiate(background, spawnpoint);
            firstBackground.GetComponent<BGIndividualScroll>().scrollSpeed = scrollSpeed;
        }
    }
}
