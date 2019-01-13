using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public GameObject recive;
    public bool isRed = true;

    void OnTriggerStay2D(Collider2D coll)
    {
        if(isRed)
        {
            recive.GetComponent<GameInputCtrl>().red_isInGround = true;
        }
        else
            recive.GetComponent<GameInputCtrl>().blue_isInGround = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (isRed)
        {
            recive.GetComponent<GameInputCtrl>().red_isInGround = false;
        }
        else
            recive.GetComponent<GameInputCtrl>().blue_isInGround = false;
    }

}
