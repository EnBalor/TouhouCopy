﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _readshot = null;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);

        GameObject readshot = Instantiate(_readshot);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            GameObject bullet = Instantiate(_bullet);
            _bullet.transform.position = this.transform.position;
            Destroy(bullet, 2f);
        }
    }
}