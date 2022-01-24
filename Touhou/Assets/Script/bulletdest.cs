using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdest : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();

    }

    void Update()
    {
        if (_rm._clearBullet == true)
        {
            Destroy(_bullet);
        }
    }
}
