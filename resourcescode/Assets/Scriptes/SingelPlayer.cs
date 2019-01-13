using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingelPlayer : MonoBehaviour
{
    public Patrol patrol = null;
    private static float speed = 6;

    void Start()
    {
        patrol.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            patrol.speed = 2;
            speed = 2;
        }
    }
}
