using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGIndividualScroll : MonoBehaviour
{
    public float scrollSpeed;
    public float deletePoint;
    // Start is called before the first frame update
    void Start()
    {
        deletePoint = -GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-scrollSpeed * Time.deltaTime,0,0), Space.World);
        if (transform.position.x < deletePoint)
        {
            Object.Destroy(this.gameObject);
        }
        
    }
}
