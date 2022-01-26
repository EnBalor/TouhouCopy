using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_fire : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _knife = null;

    float _speed = 5f;
    float _delay = 0.2f;
    float _knifefire = 1f;
    float _knifedelay = 0.3f;

    void Start()
    {
        
    }

    void Update()
    {
        _delay -= Time.deltaTime;
        _knifefire -= Time.deltaTime;

        if (_delay <= 0)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;

            _delay = 0.2f;
        }

        if(_knifefire <= 0)
        {
            for(int i = 0; i < 8; i++)
            {
                _knifedelay -= Time.deltaTime;
                if(_knifedelay <= 0)
                {
                    GameObject knife = Instantiate(_knife);
                    knife.transform.position = this.transform.position;
                    knife.transform.rotation = this.transform.rotation;
                }
            }
        }
    }
}
