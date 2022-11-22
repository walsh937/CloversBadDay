using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    /// <summary>
    /// obstacles will spawn at this game object's posiition
    /// </summary>
    public GameObject obstacle;

    public GameObject obstacleDestroyer;

    public float obstacleSpeed;
    public List<GameObject> obstacles = new List<GameObject>();

    public List<GameObject> _obstacles = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            GameObject new_obstacle = GameObject.Instantiate<GameObject>(obstacle);
            new_obstacle.transform.position = gameObject.transform.position;
            new_obstacle.transform.position += new Vector3(0, Random.Range(7, -7));
            new_obstacle.transform.Rotate(0, 0, Random.Range(0, 360));
            new_obstacle.transform.localScale = new Vector3(Random.Range(0.5f, 2), Random.Range(0.5f, 2), Random.Range(0.5f, 2));
            obstacles.Add(new_obstacle);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            print(obstacles[0]);
        }

        _obstacles = obstacles;
        foreach (GameObject obstacle_instance in obstacles)
        {
            obstacle_instance.transform.position -= new Vector3(obstacleSpeed, 0);
            if (obstacle_instance.transform.position.x < obstacleDestroyer.transform.position.x)
            {
                obstacle_instance.transform.position = gameObject.transform.position;
                obstacle_instance.transform.position += new Vector3(0, Random.Range(7, -7));
                obstacle_instance.transform.Rotate(0, 0, Random.Range(0, 360));
                obstacle_instance.transform.localScale = new Vector3(Random.Range(0.5f, 2), Random.Range(0.5f, 2), Random.Range(0.5f, 2));
            }
        }
        //obstacles = _obstacles;
    }
}