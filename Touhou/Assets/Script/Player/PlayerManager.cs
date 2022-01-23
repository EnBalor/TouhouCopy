using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    GameObject _spawn = null;

    public float _speed = 10f;

    Animator _animator;

    string _state = "State";

    Guide_Manager _gm;

    float _spawnTime = 0.5f;

    enum PlayerState
    {
        Idle = 0,
        Left = 1,
        Right = 2
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _gm = GameObject.Find("Guide").GetComponent<Guide_Manager>();
    }

    void Update()
    {
        if (_gm._hit == false)
        {
            ChangeState();

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _speed = 4f;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _speed = 10f;
            }
        }

        if(_gm._dead == true)
        {
            _spawnTime -= Time.deltaTime;
            if(_spawnTime <= 0f)
            {
                this.gameObject.SetActive(false);
                this.transform.position = _spawn.transform.position;
                _spawnTime = 0.5f;
                _gm._dead = false;
                this.gameObject.SetActive(true);
            }
        }

        if (this.transform.position.x <= -8f) this.transform.position = new Vector3(-8f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x >= 2.7f) this.transform.position = new Vector3(2.7f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.y <= -4.5f) this.transform.position = new Vector3(this.transform.position.x, -4.5f, this.transform.position.z);
        if (this.transform.position.y >= 4.5f) this.transform.position = new Vector3(this.transform.position.x, 4.5f, this.transform.position.z);
    }

    void ChangeState()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _animator.SetInteger(_state, (int)PlayerState.Left);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _animator.SetInteger(_state, (int)PlayerState.Right);
        }

        else
        {
            _animator.SetInteger(_state, (int)PlayerState.Idle);
        }
    }
}
