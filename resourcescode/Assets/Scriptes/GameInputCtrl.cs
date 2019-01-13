using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInputCtrl : MonoBehaviour
{
    public Transform red;
    public float red_speed;
    public Vector3 red_dir = Vector3.zero;
    private Rigidbody2D red_rb;

    public Transform blue;
    public float blue_speed;
    public Vector3 blue_dir = Vector3.zero;
    private Rigidbody2D blue_rb;

    private DeadMesage red_dead;
    private DeadMesage blue_dead;

    public bool use_gravity = false;
    private Vector2 gravity_mod_v2 = Vector2.zero;
    public bool red_isInGround=true;
    public bool blue_isInGround = true;

    void Start()
    {
        red_rb = red.GetComponent<Rigidbody2D>();
        blue_rb = blue.GetComponent<Rigidbody2D>();
        red_dead = red.GetComponent<DeadMesage>();
        blue_dead = blue.GetComponent<DeadMesage>();

    }

    void Update()
    {
            red_dir.y = (Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0);
            red_dir.x = (Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0);
            red_dir.y = red_dir.y * Mathf.Sqrt(1.0f - (red_dir.x * red_dir.x) * 0.5f);
            red_dir.x = red_dir.x * Mathf.Sqrt(1.0f - (red_dir.y * red_dir.y) * 0.5f);

            blue_dir.y = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);
            blue_dir.x = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            blue_dir.y = blue_dir.y * Mathf.Sqrt(1.0f - (blue_dir.x * blue_dir.x) * 0.5f);
            blue_dir.x = blue_dir.x * Mathf.Sqrt(1.0f - (blue_dir.y * blue_dir.y) * 0.5f);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
           if (Input.GetKeyDown(KeyCode.Escape))
            {
            Debug.Log("1");
             Application.Quit();
            }

    }

    void FixedUpdate()
    {

        if (use_gravity)
        {
            if (red_dead.isAlive && red_dir != Vector3.zero && red != null)
            {
                gravity_mod_v2.x = red_dir.x * red_speed;
                gravity_mod_v2.y = red_rb.velocity.y;
                if (red_dir.y > 0 && red_isInGround) red_rb.AddForce(Vector2.up*500);
                red_rb.velocity = gravity_mod_v2;
            }
            if (blue_dead.isAlive && blue_dir != Vector3.zero && blue != null)
            {
                gravity_mod_v2.x = blue_dir.x * blue_speed;
                gravity_mod_v2.y = blue_rb.velocity.y;
                if (blue_dir.y > 0 && blue_isInGround) blue_rb.AddForce(Vector2.up * 500);
                blue_rb.velocity = gravity_mod_v2;
            }
        }
        else
        {
            if (red_dead.isAlive && red_dir != Vector3.zero && red != null)
            {
                red_rb.MovePosition(red.position + red_dir * Time.fixedDeltaTime * red_speed);

            }
            if (blue_dead.isAlive && blue_dir != Vector3.zero && blue != null)
                blue_rb.MovePosition(blue.position + blue_dir * Time.fixedDeltaTime * blue_speed);
        }

    }

}
