using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    public float _speed = 1.0f;


    void Start()
    {

        Destroy(_bullet, 1f);
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");

        Vector3 dir = target.transform.position - this.transform.position;

        transform.Translate(dir * _speed * Time.deltaTime);


        //this.transform.position = Vector3.up * Time.deltaTime * _speed;

    }
}
