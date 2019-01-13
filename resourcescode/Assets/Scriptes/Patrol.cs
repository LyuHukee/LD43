using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed=2;
    public Transform[] patrol_path;
    private int current_patrol = 0;
    private Transform lookat;

    // Start is called before the first frame update
    void Start()
    {
        lookat = patrol_path[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, patrol_path[current_patrol].position) < 0.5f)
        {
            if (current_patrol < patrol_path.Length - 1)
            {
                current_patrol++;
                lookat = patrol_path[current_patrol];
            }
            else
            {
                current_patrol--;
                lookat = patrol_path[current_patrol];
            }
        }
        else
        {
            transform.Translate((lookat.position - transform.position).normalized * speed * Time.deltaTime);
        }
    }
}
