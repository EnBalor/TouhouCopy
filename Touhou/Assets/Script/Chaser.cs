using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    public float _speed = 10.0f;


    void Start()
    {

        Destroy(_bullet, 1f);
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");

        Vector3 dir = (this.transform.position - target.transform.position).normalized;

        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);

        this.transform.position = dir * Time.deltaTime * _speed;

    }
}
