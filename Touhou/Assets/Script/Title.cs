using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    [SerializeField]
    GameObject fade = null;

    [SerializeField]
    GameObject _start = null;

    [SerializeField]
    GameObject _quit = null;

    public AudioClip click;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fade.SetActive(false);
    }

    public void Onclick_start()
    {
        audioSource.clip = click;
        audioSource.Play();
        StartCoroutine("start");
    }

    IEnumerator start()
    {
        _start.SetActive(false);
        _quit.SetActive(false);
        fade.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InGame");
    }
}
