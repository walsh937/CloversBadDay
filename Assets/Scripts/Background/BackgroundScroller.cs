using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2;
    public GameObject background;
    private GameObject firstBackground;
    private float bgwidth;

    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        bgwidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        firstBackground = Instantiate(background, new Vector2(0, 0), transform.rotation);
        firstBackground.GetComponent<BGIndividualScroll>().scrollSpeed = scrollSpeed;
        firstBackground = Instantiate(background, new Vector2(bgwidth-0.2f, 0), transform.rotation);
        firstBackground.GetComponent<BGIndividualScroll>().scrollSpeed = scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstBackground == null || firstBackground.transform.position.x < 0)
        {
            firstBackground = Instantiate(background, new Vector2(bgwidth-0.2f, 0), transform.rotation);
            //firstBackground.transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime, 0, 0), Space.World);
            firstBackground.GetComponent<BGIndividualScroll>().scrollSpeed = scrollSpeed;
        }
    }
}
