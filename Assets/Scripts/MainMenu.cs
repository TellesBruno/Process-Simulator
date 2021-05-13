using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FIFO()
    {
        SceneManager.LoadScene(1);
    }
    public void RR()
    {
        SceneManager.LoadScene(2);
    }
    public void SJF()
    {
        SceneManager.LoadScene(3);
    }
    public void PRIO()
    {
        SceneManager.LoadScene(4);
    }
    public void EXIT()
    {
        Application.Quit();
    }
}
