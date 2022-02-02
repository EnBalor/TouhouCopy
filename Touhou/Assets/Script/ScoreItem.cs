using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour
{
    float _speed = 10f;
    float _chaser = 0.5f;

    Vector2 dir;

    void Start()
    {
        _chaser -= Time.deltaTime;
    }

    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - this.transform.position;
        dir.Normalize();
        transform.Translate(dir * _speed * Time.deltaTime);
        //StartCoroutine(Chaser());
    }

    IEnumerator Chaser()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - this.transform.position;
        dir.Normalize();
        transform.Translate(dir * _speed * Time.deltaTime);
    }
}
