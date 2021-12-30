using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemybullet : MonoBehaviour
{
    public float _speed = 100.0f;
    Vector3 dir;
    Rigidbody2D _rigidbody = null;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody2D>();
        GameObject target = GameObject.Find("Player");
        dir = target.transform.position - this.transform.position;
        dir.Normalize();
    }

    void Update()
    {
        transform.Translate(dir * 1f * Time.deltaTime);

        StartCoroutine(Boost());
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(dir * Time.deltaTime * _speed, Space.Self);
    }
}
