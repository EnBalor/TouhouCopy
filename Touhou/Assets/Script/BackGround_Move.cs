using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
    [SerializeField]
    GameObject _backGround = null;
    Renderer _renderer;

    float _speed = 1f;
    float _offset;


    void Start()
    {
        _renderer = _backGround.GetComponent<Renderer>();
    }

    void Update()
    {
        _offset += _speed * Time.deltaTime;
        _renderer.material.SetTextureOffset("_MainTex", new Vector2(0, _offset));
    }
}
