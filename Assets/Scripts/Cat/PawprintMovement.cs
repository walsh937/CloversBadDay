using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawprintMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public Collider2D playerCollider;
    public BlackCatBehavior catParent;
    public int luck_cost = 1;

    public float scrollSpeed = 0.5f;

    public void PawprintStart(float speed, BlackCatBehavior cat, GameObject player, GameObject mainCamera)
    {
        catParent = cat;
        scrollSpeed = speed;
        this.player = player;
        this.mainCamera = mainCamera;
        playerCollider = player.GetComponent<CharacterMovement>().characterShadow.GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x < -10.8f + mainCamera.transform.position.x)
        {
            Object.Destroy(this.gameObject);
        }
    }
    // If pawprint touches shadow and path isn't already crossed, decrement luck
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(playerCollider);
        if (collision.gameObject.GetComponent<Collider2D>() == playerCollider && catParent.pathCrossed == false)
        {
            player.GetComponent<PlayerData>().luck -= luck_cost;
            player.GetComponent<PlayerData>().UpdateUI();
            catParent.pathCrossed = true;
        }
    }
}
