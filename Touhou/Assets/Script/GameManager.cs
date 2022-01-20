using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _spawn = null;

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

    Guide_Manager _gm;

    public bool _isEnemy = false;

    public bool _isStart = false;

    public int _life = 5;

    public int _bomb = 5;

    float _spawnTime = 1f;

    void Start()
    {
        GameObject player = Instantiate(_player);
        _gm = GameObject.Find("Guide").GetComponent<Guide_Manager>();
    }

    void Update()
    {
        lifebombcount();
        //guide manager 스크립트 dead값이 트루일 때 실행
        if (_gm._dead == true)
        {
            _spawnTime -= Time.deltaTime;
            if (_spawnTime <= 0f)
            {
                if (_life != 0)
                {
                    GameObject player = Instantiate(_player);
                    player.transform.position = _spawn.transform.position;
                    _gm._dead = false;
                    _spawnTime = 1f;
                }
            }
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
            _bomb4.SetActive(false);
            _bomb3.SetActive(false);
        }

        if (_bomb == 1)
        {
            _bomb3.SetActive(false);
            _bomb2.SetActive(false);
        }

        if (_bomb == 0)
        {
            _bomb2.SetActive(false);
            _bomb1.SetActive(false);
        }
    }
}
