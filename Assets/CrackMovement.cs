using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackMovement : MonoBehaviour
{
    public float scrollSpeed = 2;
    GameObject player;
    Collider2D playerCollider;
    bool crossed = false;
    int luck_cost = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CrackStart(float scrollSpeed, GameObject player)
    {
        this.scrollSpeed = scrollSpeed;
        this.player = player;
        playerCollider = player.GetComponent<CharacterMovement>().characterShadow.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x < -11.5f)
        {
            Object.Destroy(this.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(playerCollider);
        if (collision.gameObject.GetComponent<Collider2D>() == playerCollider && crossed == false)
        {
            player.GetComponent<PlayerData>().luck -= luck_cost;
            player.GetComponent<PlayerData>().UpdateUI();
            crossed = true;
        }
    }
}