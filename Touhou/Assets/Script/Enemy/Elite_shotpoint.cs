﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_shotpoint : MonoBehaviour
{

    [SerializeField]
    GameObject _bullet = null;

    void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = -10; i < 10; i += 10)
        {
            yield return new WaitForSeconds(0.001f);
            _bullet.transform.position = this.transform.position;


            for (int j = 0; j < 3; j++)
            {
                yield return new WaitForSeconds(0.1f);
                GameObject bullet = Instantiate(_bullet);
                bullet.transform.rotation = Quaternion.Euler(0, 0, i);

                Destroy(bullet, 5f);
            }
        }
    }
}