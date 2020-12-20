using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneCh : MonoBehaviour
{
    public Canvas c;
    private void Start()
    {
        c.enabled = false;
    }

    // Start is called before the first frame update
    public void Game()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Howtoplay");
    }

    public void startS()
    {
        SceneManager.LoadScene("levels");
        
    }
    public void home()
    {
        Time.timeScale = 0;
        c.enabled = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            resume();
        }
    }
    public void resume()
    {
        Time.timeScale = 1;
        c.enabled = false;
    }
    public void GameEasy()
    {
        SceneManager.LoadScene("level_e1");
        Time.timeScale = 1;
    }
    public void GameMedium()
    {
        SceneManager.LoadScene("level_m2");
        Time.timeScale = 1;
    }
    public void GameHard()
    {
        SceneManager.LoadScene("level_h3");
        Time.timeScale = 1;
    }
    public void backS()
    {
        SceneManager.LoadScene("start");
        Time.timeScale = 1;
    }
    public void New()
    {
        SceneManager.LoadScene("new");
        Time.timeScale = 1;
    }
}