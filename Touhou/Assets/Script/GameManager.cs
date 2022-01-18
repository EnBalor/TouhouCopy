using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    public bool _isEnemy = false;

    public bool _isStart = false;

    public int _life = 5;

    public int _bomb = 5;

    void Start()
    {
        
    }

    void Update()
    {
        lifebombcount();
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
