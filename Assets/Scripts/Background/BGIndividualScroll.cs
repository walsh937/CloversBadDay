using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGIndividualScroll : MonoBehaviour
{
    public float scrollSpeed;
    public GameObject deletePoint;
    public Sprite[] bgSprites;
    private float bgwidth;
    // Start is called before the first frame update
    void Start()
    {
        bgwidth = GetComponent<SpriteRenderer>().bounds.size.x;
        deletePoint = GameObject.Find("BGDeletePoint");
        GetComponent<SpriteRenderer>().sprite = bgSprites[(int)transform.position.x/(int)bgwidth % 2];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime,0,0), Space.World);
        if (transform.position.x < deletePoint.transform.position.x)
        {
            Object.Destroy(this.gameObject);
        }
        
    }
}
