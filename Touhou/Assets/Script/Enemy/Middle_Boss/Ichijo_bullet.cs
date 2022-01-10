using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ichijo_bullet : MonoBehaviour
{
    float _speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed, Space.Self);
    }
}
