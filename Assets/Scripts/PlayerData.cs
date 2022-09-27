using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int luck = 0;
    public GameObject luckText;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateUI(); //Turn into an event based system for performance
    }

    public void UpdateUI()
    {
        luckText.GetComponent<TMP_Text>().text = "Luck: " + luck.ToString();
    }
}