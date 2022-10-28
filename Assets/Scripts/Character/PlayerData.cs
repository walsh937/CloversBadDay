using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int luck = 69420;
    public GameObject text;
    public float walk_speed = 0.10f;
    public float minimum_walk_speed = 0.10f;
    public GameObject deathScreen;

    // Start is called before the first frame update
    private void Start()
    {
        luck = 10;
    }

    public void UpdatePlayerWalkSpeed()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateUI();
        if (luck < 0)
        {
            deathScreen.GetComponent<DeathScript>().OnDeath();
            Object.Destroy(this);
            Object.Destroy(text);
        }
    }

    public void UpdateUI()
    {
        text.GetComponent<TMP_Text>().text = string.Format("Luck: {0}", luck);
    }
}