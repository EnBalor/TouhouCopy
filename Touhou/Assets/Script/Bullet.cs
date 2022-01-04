using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    public float _speed = 10.0f;


    void Start()
    {
        Destroy(_bullet, 1f);

    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }
}
