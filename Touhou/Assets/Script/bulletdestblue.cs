using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestblue : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _bluedest = null;

    [SerializeField]
    GameObject _scoreitem = null;

    Bullet_clear _bc;

    void Start()
    {
        _bc = GameObject.Find("BulletClear").GetComponent<Bullet_clear>();
    }

    void Update()
    {
        if (_bc._bulletclear == true)
        {
            GameObject bluedest = Instantiate(_bluedest);
            bluedest.transform.position = this.transform.position;
            Destroy(bluedest, 1f);
            Destroy(_bullet);

            GameObject scoreitem = Instantiate(_scoreitem);
            scoreitem.transform.position = this.transform.position;

            Destroy(scoreitem, 0.5f);
        }
    }
}
