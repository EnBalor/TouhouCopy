using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _counter = null;

    CircleCollider2D _coll;

    SpriteRenderer _renderer;

    GameManager _gm;

    Reimu _rm;

    Bullet_clear _bc;

    ScoreManager _sc;

    public AudioClip _item;
    public AudioClip _deadsound;

    AudioSource audioSource;

    public float _speed = 5f;

    public bool _hit = false;
    public bool _dead = false;
    public bool _counterbomb = false;

    float _counterTime = 0f;
    float _deadTime = 0.5f;
    float _untouch = 0.5f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _renderer = this.GetComponent<SpriteRenderer>();
        _coll = this.transform.gameObject.GetComponent<CircleCollider2D>();
        _bc = GameObject.Find("BulletClear").GetComponent<Bullet_clear>();
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
            _untouch -= Time.deltaTime;

            _coll.isTrigger = false;
            if (_counterTime <= _deadTime && _gm._bomb > 0)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    GameObject.Find("Player").GetComponent<Reimu>().Bomb();
                    _counterTime = 0f;
                    _counterbomb = true;
                    _gm._bomb -= 2;
                    _hit = false;
                    _bc._bulletclear = true;
                }
            }

            else if (_counterTime >= _deadTime)
            {
                _gm._life -= 1;
                _counterTime = 0f;
                _hit = false;
                _dead = true;
                _bc._bulletclear = true;
            }

            if(_counterTime <= 0f)
            {
                _counterbomb = false;
            }

            Debug.Log("playerhit");
        }

        if(_hit == false)
        {
            _coll.isTrigger = true;
        }

        if (_untouch <= 0)
        {
            _coll.isTrigger = true;
        }

        if (Input.GetKey(KeyCode.Alpha0))
        {
            this.gameObject.SetActive(false);
        }

        if(_counterbomb == true)
        {
            _counterbomb = false;
        }

        if(_dead == true)
        {
            _gm._bomb = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_bullet")
        {
            audioSource.clip = _deadsound;
            audioSource.Play();

            _hit = true;

            GameObject counter = Instantiate(_counter);
            counter.transform.position = this.transform.position;
            Destroy(counter, 0.5f);
        }

        if (collision.tag == "Score")
        {
            audioSource.clip = _item;
            audioSource.Play();

            ScoreManager.Instance.addscore(100);
        }
    }
}
