using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShadow : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void SetShadow(bool enabled = false)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = enabled;
        gameObject.GetComponent<Collider2D>().enabled = enabled;
    }
}