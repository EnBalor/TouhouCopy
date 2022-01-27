using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet : MonoBehaviour
{
    public float _speed = 5f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
    }
}
