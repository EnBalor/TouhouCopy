using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_clear : MonoBehaviour
{
    public bool _bulletclear;

    void Start()
    {
        _bulletclear = false;
    }

    void Update()
    {
        Debug.Log(_bulletclear);
    }
}
