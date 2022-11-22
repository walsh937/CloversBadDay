using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public int testint = 0;
    public Collider2D playerCollider;
    public DeathScript deathScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1f, 0,0) * Time.deltaTime;   
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() == playerCollider)        {
            print("sds");
            deathScript.OnDeath();
        }
    }
}
