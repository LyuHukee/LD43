using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChasePlayer : MonoBehaviour
{
    public Transform[] player_path = new Transform[2];
    private Transform lookat;

    public float speed = 4f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lookat = player_path[0];
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (lookat.position - transform.position).normalized * Time.fixedDeltaTime * speed);
    }

    void NextAim()
    {
        lookat = lookat == player_path[0] ? player_path[1] : player_path[0];
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            if (coll.collider.GetComponent<DeadMesage>().isAlive)
            {
                coll.collider.GetComponent<DeadMesage>().Dead();
            }
            NextAim();
        }
    }

}
