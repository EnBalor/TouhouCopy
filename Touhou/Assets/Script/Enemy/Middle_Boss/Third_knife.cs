using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_knife : MonoBehaviour
{
    float _speed = 2f;
    float _rotspeed = 100f;

    float _movetime = 2.5f;

    float _chaser = 4f;
    float _chaserspeed = 1f;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
        

        if (_chaser <= 0)
        {
            //_speed = 0;

            
        }
    }

    void Update()
    {
        _chaser -= Time.deltaTime;
        _movetime -= Time.deltaTime;
        Debug.Log(_chaser);

        if (_chaser >= 0)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        }

        else if(_chaser <= 0)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            Vector3 dir = target.transform.position - this.transform.position;

            if (target != null)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 180f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, _rotspeed * Time.deltaTime);
                transform.rotation = rotation;

                _chaser = 1f;

                transform.Translate(dir * _chaserspeed * Time.deltaTime);

            }

            else
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
            }
        }

        if (_rm._clearBullet == true)
        {
            Destroy(this);
        }
    }
}
