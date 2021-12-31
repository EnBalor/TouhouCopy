using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_first_Bullet : MonoBehaviour
{
    [SerializeField]
    GameObject _shotPoint = null;

    public float _speed = 5f;
    
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 dir = _shotPoint.transform.right;

        transform.Translate(dir * _speed * Time.deltaTime, Space.Self);

        //StartCoroutine(Boost());
    }

    IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
    }
}
