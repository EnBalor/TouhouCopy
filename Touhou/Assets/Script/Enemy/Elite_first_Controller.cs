using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_first_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject _hexagram = null;

    //[SerializeField]
    //GameObject _shotPoint = null;

    public float _speed = 5f;

    void Start()
    {
       //for (int i = 0; i < 360; i += 72)
       //{
       //    Vector3 pos = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0);
       //
       //    GameObject shotPoint = Instantiate(_shotPoint);
       //
       //    shotPoint.transform.right = pos;
       //    shotPoint.transform.position = pos * 1.5f;
       //}

        for (int i = 0; i < 360; i += 24)
        {
            Vector3 pos = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0);

            GameObject hexagram = Instantiate(_hexagram);

            hexagram.transform.right = pos;
            hexagram.transform.position = pos * 1.5f;
        }
    }

    void Update()
    {
       
    }
}