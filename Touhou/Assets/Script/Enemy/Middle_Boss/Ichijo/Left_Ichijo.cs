using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Ichijo : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    float _fire = 0.08f;
    float _delay = 0.08f;

    public float _speed = 10f;

    public float _rotSpeed = 1f;

    Boss_Manager _bm;

    void Start()
    {
        _bm = GameObject.Find("Mokou").GetComponent<Boss_Manager>();
    }

    void Update()
    {
        if (_bm._ichijopattern == true)
        {
            _fire += Time.deltaTime;

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

            Vector3 dir = new Vector3(0, 0, _rotSpeed);
        }
        //this.transform.Rotate(dir.normalized);
    }
}