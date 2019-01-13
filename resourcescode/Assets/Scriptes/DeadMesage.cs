using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMesage : MonoBehaviour
{
    public GameObject dead_mesage;

    public bool isAlive = true;

    public void Dead()
    {
        if (!isAlive) return;
        isAlive = false;
        dead_mesage.SetActive(true);
    }


}
