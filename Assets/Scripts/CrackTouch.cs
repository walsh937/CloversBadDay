using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackTouch : MonoBehaviour
{
    public GameObject player;
    public int luck_cost = 1;

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
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerData>().luck -= luck_cost;
            player.GetComponent<PlayerData>().UpdateUI();
        }
    }
}