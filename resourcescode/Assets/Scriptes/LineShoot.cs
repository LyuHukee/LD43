using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineShoot : MonoBehaviour
{
    private LineRenderer line;
    public Vector2 distance = new Vector2(-100,0);
    RaycastHit2D ray;

    private Vector2 v2;

    public LayerMask mask;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        v2 = new Vector2(transform.position.x, transform.position.y);
    }
  
    void Update()
    {
        v2.x = transform.position.x;
        v2.y = transform.position.y;
        ray = Physics2D.Linecast(v2, v2 + distance, mask);
        line.SetPosition(0, ray.point - v2);
        if (ray.collider.tag == "Player")
        {
            ray.collider.GetComponent<DeadMesage>().Dead();
        }
    }



}
