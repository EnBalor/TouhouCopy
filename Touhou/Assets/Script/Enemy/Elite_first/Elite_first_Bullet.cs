﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_first_Bullet : MonoBehaviour
{
    public float _speed = 5f;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);

    }

}