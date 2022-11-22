using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackMovement : MonoBehaviour
{
    public float scrollSpeed = 2;
    private GameObject player;
    private GameObject mainCamera;
    private Collider2D playerCollider;
    private bool crossed = false;
    private int luck_cost = 1;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void CrackStart(float scrollSpeed, GameObject player)
    {
        this.scrollSpeed = scrollSpeed;
        this.player = player;
        playerCollider = player.GetComponent<CharacterMovement>().characterShadow.GetComponent<Collider2D>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    private void Update()
    {

        transform.Translate(-scrollSpeed * Time.deltaTime, 0, 0, Space.World);
        if (transform.position.x < -11.5f + mainCamera.GetComponent<CameraController>().getCameraCreep())
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>() == playerCollider && crossed == false)
        {
            player.GetComponent<PlayerData>().luck -= luck_cost;
            player.GetComponent<PlayerData>().UpdateUI();
            crossed = true;
        }
    }
}