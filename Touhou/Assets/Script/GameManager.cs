using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _life1 = null;

    [SerializeField]
    GameObject _life2 = null;

    [SerializeField]
    GameObject _life3 = null;

    [SerializeField]
    GameObject _life4 = null;

    [SerializeField]
    GameObject _life5 = null;

    [SerializeField]
    GameObject _bomb1 = null;

    [SerializeField]
    GameObject _bomb2 = null;

    [SerializeField]
    GameObject _bomb3 = null;

    [SerializeField]
    GameObject _bomb4 = null;

    [SerializeField]
    GameObject _bomb5 = null;

    [SerializeField]
    GameObject _retry = null;

    [SerializeField]
    GameObject _boss = null;

    [SerializeField]
    GameObject _retryyes = null;

    [SerializeField]
    GameObject _retryno = null;

    [SerializeField]
    GameObject _fade = null;

    public AudioClip bgm;

    AudioSource audioSource;

    Boss_Manager _bm;


    public bool _isEnemy = false;

    public bool _isStart = false;

    public int _life;

    public int _bomb;

    float _spawn = 2f;

    void Start()
    {
        _bm = GameObject.Find("Mokou").GetComponent<Boss_Manager>();
        audioSource = GetComponent<AudioSource>();
        _fade.SetActive(true);
        _retryyes.SetActive(false);
        _retryno.SetActive(false);
        _boss.SetActive(false);
        _player.SetActive(true);
        _retry.SetActive(false);
        _isStart = true;
        _life = 5;
        _bomb = 5;
    }

    void Update()
    {
        _spawn -= Time.deltaTime;
        if(_spawn < 0)
        {
            _boss.SetActive(true);
        }

        lifebombcount();

        if(_life < 0)
        {
            _retry.SetActive(true);
            _retryyes.SetActive(true);
            _retryno.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
    }

    void lifebombcount()
    {
        if (_life == 4)
        {
            _life5.SetActive(false);
        }

        if (_life == 3)
        {
            _life4.SetActive(false);
        }

        if (_life == 2)
        {
            _life3.SetActive(false);
        }

        if (_life == 1)
        {
            _life2.SetActive(false);
        }

        if (_life == 0)
        {
            _life1.SetActive(false);
        }

        if(_bomb == 5)
        {
            _bomb5.SetActive(true);
            _bomb4.SetActive(true);
            _bomb3.SetActive(true);
            _bomb2.SetActive(true);
            _bomb1.SetActive(true);
        }

        if (_bomb == 4)
        {
            _bomb5.SetActive(false);
        }

        if (_bomb == 3)
        {
            _bomb5.SetActive(false);
            _bomb4.SetActive(false);
        }

        if (_bomb == 2)
        {
            _bomb5.SetActive(false);
            _bomb4.SetActive(false);
            _bomb3.SetActive(false);
        }

        if (_bomb == 1)
        {
            _bomb5.SetActive(false);
            _bomb4.SetActive(false);
            _bomb3.SetActive(false);
            _bomb2.SetActive(false);
        }

        if (_bomb == 0)
        {
            _bomb5.SetActive(false);
            _bomb4.SetActive(false);
            _bomb3.SetActive(false);
            _bomb2.SetActive(false);
            _bomb1.SetActive(false);
        }
    }
}
