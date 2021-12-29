using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float _speed = 5.0f;

    Animator _animator;

    string _state = "State";

    enum PlayerState
    {
        Idle = 0,
        Left = 1,
        Right = 2
    }

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
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
