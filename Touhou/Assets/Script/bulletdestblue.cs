using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestblue : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _bluedest = null;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
    }

    void Update()
    {
        if (_rm._clearBullet == true)
        {
            GameObject bluedest = Instantiate(_bluedest);
            bluedest.transform.position = this.transform.position;
            Destroy(bluedest, 1f);
            Destroy(_bullet);
        }
    }
}
