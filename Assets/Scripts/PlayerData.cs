using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public int luck = 69420;
    public GameObject text;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        text.GetComponent<TMP_Text>().text = string.Format("luck: {0}", luck);
    }
}