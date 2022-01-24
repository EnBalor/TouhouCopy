using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _spawnPoint = null;

    [SerializeField]
    GameObject _counter = null;

    CircleCollider2D _coll;

    SpriteRenderer _renderer;

    GameManager _gm;

    Reimu _rm;

    public float _speed = 5f;

    public bool _hit = false;
    public bool _dead = false;

    float _counterTime = 0f;
    float _deadTime = 0.5f;

    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _renderer = this.GetComponent<SpriteRenderer>();
        _coll = this.transform.gameObject.GetComponent<CircleCollider2D>();
        _rm = this.GetComponent<Reimu>();
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

        if(_hit == true)
        {
            _counterTime += Time.deltaTime;
            
            _coll.isTrigger = false;
            if (_counterTime <= _deadTime)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        _gm._bomb -= 1;
                    }
                    _counterTime = 0f;
                    _hit = false;
                }
            }

            else if (_counterTime >= _deadTime)
            {
                _gm._life -= 1;
                _counterTime = 0f;
                _hit = false;
                _dead = true;
                _coll.isTrigger = true;
            }
            Debug.Log("playerhit");
        }

        if(Input.GetKey(KeyCode.Alpha0))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_bullet")
        {
            _hit = true;

            GameObject counter = Instantiate(_counter);
            counter.transform.position = this.transform.position;
        }
    }
}
