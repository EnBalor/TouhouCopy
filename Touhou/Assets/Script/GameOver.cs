using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick_retry()
    {
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1f;
    }

    public void Onclick_exit()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }
}
