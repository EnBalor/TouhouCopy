using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullet : MonoBehaviour
{
    public float _speed = 5f;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(_rm._clearBullet == true)
        {
            Destroy(this);
        }
    }
}
