﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _pattern1 = null;

    [SerializeField]
    GameObject _pattern2 = null;

    [SerializeField]
    GameObject _pattern3 = null;

    [SerializeField]
    GameObject _pattern4 = null;

    [SerializeField]
    GameObject _leftichijo = null;

    [SerializeField]
    GameObject _rightichijo = null;

    public int _firstHP = 1000;
    public int _ichijoHP = 1000;

    float _delay = 0f;
    float _first = 2f;

    Boss_shotController _firstPattern;

    Boss_Left_ichijo _secondPattern;
    Boss_Right_ichijo _secondPattern2;

    public bool _fstpattern;
    public bool _ichijopattern;

    void Start()
    {
        _firstPattern = GetComponent<Boss_shotController>();

        _secondPattern = GetComponent<Boss_Left_ichijo>();
        _secondPattern2 = GetComponent<Boss_Right_ichijo>();

        _pattern1.SetActive(false);
        _pattern2.SetActive(false);
        _pattern3.SetActive(false);
        _pattern4.SetActive(false);

        _leftichijo.SetActive(false);
        _rightichijo.SetActive(false);
    }

    void Update()
    {
        _delay += Time.deltaTime;

        if(_delay >= _first)
        {
            _fstpattern = true;
            _pattern1.SetActive(true);
            _pattern2.SetActive(true);
            _pattern3.SetActive(true);
            _pattern4.SetActive(true);
        }

        if(_firstHP <= 0)
        {
            _fstpattern = false;
            _pattern1.SetActive(false);
            _pattern2.SetActive(false);
            _pattern3.SetActive(false);
            _pattern4.SetActive(false);

            _ichijopattern = true;
            _leftichijo.SetActive(true);
            _rightichijo.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _firstHP -= 1000;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _ichijoHP -= 1000;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_bullet")
        {
            if (_firstHP >= 0)
            {
                _firstHP -= 1;
                Debug.Log("bosshit");
            }
            else if (_firstHP <= 0)
            {
                _ichijoHP -= 1;
                Debug.Log("ichijoHit");
            }
        }
    }
}