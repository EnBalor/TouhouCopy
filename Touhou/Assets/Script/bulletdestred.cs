using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestred : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _reddest = null;

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
            GameObject reddest = Instantiate(_reddest);
            reddest.transform.position = this.transform.position;
            Destroy(reddest, 1f);
            Destroy(_bullet);

            GameObject scoreitem = Instantiate(_scoreitem);
            scoreitem.transform.position = this.transform.position;

            Destroy(scoreitem, 0.5f);
        }
    }
}
