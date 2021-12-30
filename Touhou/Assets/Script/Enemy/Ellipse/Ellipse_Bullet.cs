using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse_Bullet : MonoBehaviour
{
    public float _speed = 5f;
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
        transform.Translate(Vector3.down * 1f * Time.deltaTime);

        StartCoroutine(Boost());
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Translate(Vector3.down * Time.deltaTime * _speed, Space.Self);
    }
}
