using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestred : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _reddest = null;

    Reimu _rm;

    void Start()
    {
        _rm = GameObject.Find("Player").GetComponent<Reimu>();
    }

    void Update()
    {
        if (_rm._clearBullet == true)
        {
            GameObject reddest = Instantiate(_reddest);
            reddest.transform.position = this.transform.position;
            Destroy(reddest, 1f);
            Destroy(_bullet);
        }
    }
}
