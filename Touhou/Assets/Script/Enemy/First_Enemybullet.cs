using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemybullet : MonoBehaviour
{
    [SerializeField]
    GameObject _readshot = null;

    public float _speed = 100.0f;
    Vector3 dir;
    Rigidbody2D _rigidbody = null;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        GameObject target = _readshot;
        dir = target.transform.position - this.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        _rigidbody.AddForce(dir * _speed * Time.deltaTime);
    }
}