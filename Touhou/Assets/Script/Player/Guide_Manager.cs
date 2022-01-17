using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _player = null;

    SpriteRenderer _renderer;

    GameManager _gm;

    public float _speed = 5f;

    public bool _dead = false;

    float _counterTime = 0f;
    float _deadTime = 0.5f;

    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _renderer = this.GetComponent<SpriteRenderer>();
        _renderer.enabled = false;
    }

    void Update()
    {
        Vector3 dir = new Vector3(0, 0, _speed * Time.deltaTime);

        this.transform.Rotate(-(dir.normalized));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _renderer.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _renderer.enabled = false;
        }

        if(_dead == true)
        {
            _counterTime += Time.deltaTime;
            if (_counterTime <= _deadTime)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    _gm._bomb -= 2;
                    _counterTime = 0f;
                    _dead = false;
                }
            }

            else if (_counterTime >= _deadTime)
            {
                Destroy(_player);
                _gm._life -= 1;
                _counterTime = 0f;
                _dead = false;
            }
            Debug.Log("playerhit");
            Debug.Log(_gm._life);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_bullet")
        {
            _dead = true;
        }
    }
}
