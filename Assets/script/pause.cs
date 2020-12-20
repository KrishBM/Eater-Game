using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    public GameObject pauseb;
    public GameObject playb;
    public Canvas c;

    public void pause1()
    {
        Time.timeScale = 0;
        pauseb.SetActive(false);
        playb.SetActive(true);
        
    }
    public void resume()
    {
        Time.timeScale = 1;
        pauseb.SetActive(true);
        playb.SetActive(false);
    }
    public void resume1()
    {
        Time.timeScale = 1;
        c.enabled = false;
    }

}
