using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_knife : MonoBehaviour
{
    float _speed = 4f;

    float _chaser = 3f;
    float _chaserspeed = 3f;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        _chaser -= Time.deltaTime;

        if (_chaser >= 0)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        }

        else if(_chaser <= 0)
        {
            if (target != null)
            {
                Vector3 dir = target.transform.position - this.transform.position;

                transform.Translate(dir * _chaserspeed * Time.deltaTime);
            }
        }

        if (_rm._clearBullet == true)
        {
            Destroy(this);
        }
    }
}
