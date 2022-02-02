using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_knife : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    float _speed = 2f;

    float _chaser = 4f;
    float _chaserspeed = 1f;

    Reimu _rm;

    Vector3 dir;


    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();

        GameObject target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - _bullet.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        _chaser -= Time.deltaTime;

        transform.Translate(dir * _speed * Time.deltaTime, Space.Self);

        if (_chaser <= 0)
        {
            _speed = 0f;

            transform.Translate(dir * _chaserspeed * Time.deltaTime, Space.Self);
            
        }

        if (_rm._clearBullet == true)
        {
            Destroy(this);
        }
    }
}
