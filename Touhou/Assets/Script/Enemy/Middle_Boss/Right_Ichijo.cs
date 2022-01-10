using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Ichijo : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    float _fire = 0.01f;
    float _delay = 0.01f;

    float _stop = 0f;
    float _isStop = 0.02f;

    float _fireTime = 0f;
    float _firing = 0.08f;

    public float _speed = 10f;

    public float _rotSpeed = 5f;

    void Start()
    {
    }

    void Update()
    {
        _fire += Time.deltaTime;
        _fireTime += Time.deltaTime;
        _stop += Time.deltaTime;

        if (_stop >= _isStop)
        {

            if (_fireTime >= _firing)
            {
                _stop = 0f;
            }

            if (_fire >= _delay)
            {
                GameObject bullet = Instantiate(_bullet);

                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = this.transform.rotation;

                _fire = 0f;

                Destroy(bullet, 3f);
            }

            GameObject _shotPoint = transform.parent.gameObject;

            float _distance = Vector3.Distance(this.transform.position, _shotPoint.transform.position);

            this.transform.Translate(Vector2.down * _speed * Time.deltaTime, Space.Self);

            if (_distance >= 15f)
            {
                _speed = 0f;
            }
        }
        Vector3 dir = new Vector3(0, 0, _rotSpeed * Time.deltaTime);

        //this.transform.Rotate(-(dir.normalized));
    }
}