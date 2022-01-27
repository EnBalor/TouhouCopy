using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_knife : MonoBehaviour
{
    float _speed = 2f;
    float _rotspeed = 100f;

    float _movetime = 2.5f;

    float _chaser = 3f;
    float _chaserspeed = 1f;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = Vector3.down;

        _chaser -= Time.deltaTime;
        _movetime -= Time.deltaTime;

        if (_chaser >= 0)
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);
        }

        else if(_chaser <= 0)
        {
            _speed = 0f;

            if (target != null)
            {

                dir = new Vector3(this.transform.position.x - target.transform.position.x, this.transform.position.y - target.transform.position.y, 0);

                transform.Translate(dir * _chaserspeed * Time.deltaTime);

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, _rotspeed * Time.deltaTime);
                transform.rotation = rotation;
            }

            else
            {
                transform.Translate(dir * _speed * Time.deltaTime, Space.Self);
            }
        }

        if (_rm._clearBullet == true)
        {
            Destroy(this);
        }
    }
}
