using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject character;
    public GameObject background;
    private float bgwidth;
    public float cameraCreepMultiplier = 1;
    private float cameraCreep = 0;
    public float cameraCreepDragDist = 3;
    private float lastPos = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        bgwidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
        Instantiate(background, new Vector2(bgwidth, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
        cameraCreep += Time.deltaTime * cameraCreepMultiplier;
        Debug.Log(Mathf.Max(character.transform.position.x, cameraCreep));
        transform.position = new Vector3(Mathf.Max(character.transform.position.x, cameraCreep), 0, -15);
        // Spawn background if necessary
        if (Mathf.Floor(transform.position.x / bgwidth) != lastPos)
        {
            lastPos = Mathf.Floor(transform.position.x / 10);
            Instantiate(background, new Vector2(lastPos*bgwidth,0), transform.rotation);
        }
        if (cameraCreep - character.transform.position.x > cameraCreepDragDist)
        {
            // push the player forward if camera has caught up
            character.transform.position = new Vector3(cameraCreep - cameraCreepDragDist, character.transform.position.y, 0);
        }
    }
}
