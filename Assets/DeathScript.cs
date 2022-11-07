using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public GameObject deathCamera;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame

    public void OnDeath()
    {
        Camera.main.enabled = false;
        deathCamera.GetComponent<Camera>().enabled = true;
    }

    private void Update()
    {
    }
}