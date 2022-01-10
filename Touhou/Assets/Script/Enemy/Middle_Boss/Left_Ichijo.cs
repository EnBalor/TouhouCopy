using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Ichijo : MonoBehaviour
{
    public float _speed = 10f;

    public float _rotSpeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector2.down * _speed * Time.deltaTime, Space.Self);

        Vector3 dir = new Vector3(0, 0, _rotSpeed);

        this.transform.Rotate(-(dir.normalized));
    }
}