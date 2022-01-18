using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu_bomb : MonoBehaviour
{
    [SerializeField]
    GameObject _bomb = null;

    [SerializeField]
    GameObject _player = null;

    Boss_Manager _bossManager;

    public float _speed = 3.0f;
    float _chaserSpeed = 5f;

    float _wait = 0f;
    float _chaser = 1f;

    void Start()
    {
        _bossManager = GetComponent<Boss_Manager>();
        Destroy(_bomb, 5f);
    }

    void Update()
    {
        _wait += Time.deltaTime;

        if(_wait <= _chaser)
        {
            _bomb.transform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        else if (_wait >= _chaser)
        {
            float _distance = Vector3.Distance(_player.transform.position, _bomb.transform.position);

            if (_distance >= 2f)
            {
                _speed = 0f;
            }

            GameObject target = GameObject.FindGameObjectWithTag("Enemy");

            Vector3 dir = target.transform.position - _bomb.transform.position;

            transform.Translate(dir * _chaserSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(_bomb);
            Debug.Log("chaser");
        }
    }
}
