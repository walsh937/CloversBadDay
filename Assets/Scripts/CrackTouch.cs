using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackTouch : MonoBehaviour
{
    public GameObject player;
    public Collider2D playerCollider;
    public GameObject CrackSpawner;
    public int luck_cost = 1;
    public bool crack_has_been_touched = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() == playerCollider && crack_has_been_touched == false)
        {
            player.GetComponent<PlayerData>().luck -= luck_cost;
            player.GetComponent<PlayerData>().UpdateUI();
            crack_has_been_touched = true;
            CrackSpawner.GetComponent<CrackSpawner>().UpdateCrackSpeed(multiply_walk_speed_by: 0.5f);
        }
    }
}