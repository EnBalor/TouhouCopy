using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shotController : MonoBehaviour
{
    public float _rotSpeed = 200f;

    [SerializeField]
    GameObject _bullet = null;

    float _fire = 10f;
    float _rot = 0f;
    float _delay = 10f;

    int _rottime = 0;
    int _rotate = 2;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject _left = GameObject.FindGameObjectWithTag("Left");
        GameObject _right = GameObject.FindGameObjectWithTag("Right");

        _fire++;
        _rot++;

        if(CompareTag("Right") == true)
        {
            if (_rot >= _delay)
            {
                this.transform.Rotate(0, 0, -(_rotSpeed * Time.deltaTime));
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
            if (_rot >= _delay)
            {
                this.transform.Rotate(0, 0, (_rotSpeed * Time.deltaTime));
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
}