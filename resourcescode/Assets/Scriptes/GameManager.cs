using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    #region SingelMod
    private static object locker = new Object();
    private static volatile GameManager singel;
    public static GameManager Instance
    {
        get
        {
            if (singel == null)
            {
                lock (locker)
                {
                    if (singel == null)
                        singel = new GameManager();
                }
            }
            return singel;
        }
    }
    #endregion

    public int scence_number = 0;
    
    public void NextScene()
    {
        scence_number += 1;
        if (scence_number > 9)
        {
            scence_number = 0;
        }
        SceneManager.LoadScene(scence_number);
    }

}
