﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemymove : MonoBehaviour
{
    [SerializeField]
    GameObject _first = null;

    public float _speed = 5.0f;
    public float _rotspeed = 5.0f;

    float _limit = 0;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed);
        StartCoroutine(Rot());
    }

    IEnumerator Rot()
    {
        yield return new WaitForSeconds(1.0f);

        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);

        if (this.transform.position.x >= 0)
        {
            _first.transform.Rotate(Vector2.down * _rotspeed * 100 * Time.deltaTime);
        }

        else if (this.transform.position.x <= 0)
        {
            _first.transform.rotation = Quaternion.Euler(0, 0, -(_rotspeed * Time.deltaTime));

        }
    }
}
