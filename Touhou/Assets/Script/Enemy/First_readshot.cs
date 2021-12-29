using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_readshot : MonoBehaviour
{
    public float _speed = 5.0f;
    Vector3 dir;
    Rigidbody2D _rigidbody = null;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        GameObject target = GameObject.Find("Player");
        dir = target.transform.position - this.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        _rigidbody.AddForce(dir * _speed * Time.deltaTime);
    }
}
