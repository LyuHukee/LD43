using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // public GameObject[] player;
    public Transform lookat;
    private Rigidbody2D rb;
    public float speed = 7f;

    public Transform[] patrol_path;
    private int current_patrol=0;

    private bool isInChase = true;
    public float distance = 1;
    
    void Start()
    {
        // player = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
     
    }

    void Update()
    {
        if (patrol_path.Length >= 2)
        {
            if (lookat == null)
            {
                lookat = patrol_path[current_patrol];
                isInChase = false;
            }
            else if (!isInChase)
            {
                DoPatrol();
            }
        }

    }

    void FixedUpdate()
    {
        if (lookat == null) return;
        rb.MovePosition(transform.position + (lookat.position - transform.position).normalized * Time.fixedDeltaTime * speed);
    }

    void DoPatrol()
    {  
        if (Vector3.Distance(transform.position, patrol_path[current_patrol].position) < distance)
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
    }


    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            if(coll.collider.GetComponent<DeadMesage>().isAlive)
            {
                coll.collider.GetComponent<DeadMesage>().Dead();
                lookat = null;
            }
            else lookat = null;
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if(coll.GetComponent<DeadMesage>().isAlive)
            {
                isInChase = true;
                lookat = coll.gameObject.transform;
            }
        }
    }

}
