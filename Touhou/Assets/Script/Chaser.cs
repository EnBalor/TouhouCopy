using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    Boss_Manager _bossManager;

    public float _speed = 1.0f;

    void Start()
    {
        _bossManager = GetComponent<Boss_Manager>();
        Destroy(_bullet, 1f);
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");

        if (target != null)
        {
            Vector3 dir = target.transform.position - this.transform.position;

            transform.Translate(dir * _speed * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(_bullet);
            Debug.Log("chaser");
        }
    }
}
