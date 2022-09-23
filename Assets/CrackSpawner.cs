using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSpawner : MonoBehaviour
{
    /// <summary>
    /// Cracks will spawn at this game object's posiition
    /// </summary>
    public GameObject crack;

    public GameObject crackDestroyer;

    public float crackSpeed;
    public List<GameObject> cracks = new List<GameObject>();

    public List<GameObject> _cracks = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            GameObject new_crack = GameObject.Instantiate<GameObject>(crack);
            new_crack.transform.position = gameObject.transform.position;
            new_crack.transform.position += new Vector3(0, Random.Range(7, -7));
            cracks.Add(new_crack);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            print(cracks[0]);
        }

        _cracks = cracks;
        foreach (GameObject crack_instance in cracks)
        {
            crack_instance.transform.position -= new Vector3(crackSpeed, 0);
            if (crack_instance.transform.position.x < crackDestroyer.transform.position.x)
            {
                Destroy(crack_instance);
                _cracks.Remove(crack_instance);
            }
        }
        //cracks = _cracks;
    }
}