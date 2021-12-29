using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemymove : MonoBehaviour
{
    public float _speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed);
    }
}
