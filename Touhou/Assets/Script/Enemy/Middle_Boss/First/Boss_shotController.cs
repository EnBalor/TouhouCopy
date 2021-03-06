using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shotController : MonoBehaviour
{
    float _rotSpeed = 1f;

    [SerializeField]
    GameObject _bullet = null;

    float _fire = 0.1f;
    float _delay = 0.1f;

    float _rot = 0f;
    float _rotateTime = 0.3f;

    float _timer = 0;
    float _stopTimer = 2f;
    float _secondTimer = 5f;

    Boss_Manager _bm;

    void Start()
    {
        _bm = GameObject.Find("Mokou").GetComponent<Boss_Manager>();
    }

    void Update()
    {
        if (_bm._fstpattern == true)
        {
            Vector3 dir = new Vector3(0, 0, _rotSpeed * Time.deltaTime);

            GameObject _left = GameObject.FindGameObjectWithTag("Left");
            GameObject _right = GameObject.FindGameObjectWithTag("Right");

            _timer += Time.deltaTime;

            if (_timer <= _stopTimer)
            {
                _fire += Time.deltaTime;
                _rot += Time.deltaTime;

                if (CompareTag("Right") == true)
                {

                    if (_rot >= _rotateTime)
                    {
                        this.transform.Rotate(-(dir.normalized));
                    }

                    if (_fire >= _delay)
                    {
                        GameObject bullet = Instantiate(_bullet);

                        bullet.transform.position = this.transform.position;
                        bullet.transform.rotation = this.transform.rotation;

                        _fire = 0f;

                        Destroy(bullet, 3f);
                    }
                }

                if (CompareTag("Left") == true)
                {

                    if (_rot >= _rotateTime)
                    {
                        this.transform.Rotate((dir.normalized));
                    }

                    if (_fire >= _delay)
                    {
                        GameObject bullet = Instantiate(_bullet);

                        bullet.transform.position = this.transform.position;
                        bullet.transform.rotation = this.transform.rotation;

                        _fire = 0f;

                        Destroy(bullet, 3f);
                    }
                }
            }

            if (_timer >= _secondTimer)
            {
                _timer = 0f;
            }
        }
    }
}