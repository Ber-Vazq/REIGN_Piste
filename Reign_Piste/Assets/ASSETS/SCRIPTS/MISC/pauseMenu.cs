using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pMenu;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
    }
    
    public void TogglePause()
    {
        isPaused =!isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pMenu.SetActive(isPaused);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pMenu.SetActive(true);
        isPaused = true;
        Debug.Log("Button was clicked: " + gameObject.name);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pMenu.SetActive(false);
        isPaused = false;
        Debug.Log("Button was clicked: " + gameObject.name);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Button was clicked: " + gameObject.name);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Button was clicked: " + gameObject.name);
    }
}
