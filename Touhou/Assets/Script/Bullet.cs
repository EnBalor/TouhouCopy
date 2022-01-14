using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    Boss_Manager _bossManager;

    public float _speed = 10.0f;


    void Start()
    {
        _bossManager = GetComponent<Boss_Manager>();
        Destroy(_bullet, 1f);

    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(_bullet);
            Debug.Log("hit");
        }
    }
}
