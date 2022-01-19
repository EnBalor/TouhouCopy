﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_bomb : MonoBehaviour
{
    [SerializeField]
    GameObject _bomb = null;

    [SerializeField]
    GameObject _explode = null;

    float _speed = 5.0f;

    [Range(2f, 10f)]
    float _addscale = 3f;

    void Start()
    {
        Destroy(_bomb, 5f);
    }

    void Update()
    {
        _bomb.transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(_bomb);
            GameObject explode = Instantiate(_explode);
            explode.transform.position = _bomb.transform.position;
            Debug.Log("chaser");
            Destroy(explode, 4f);
        }
    }
}
