using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third : MonoBehaviour
{
    [SerializeField]
    GameObject _thirdPoint = null;

    [SerializeField]
    GameObject _thirdKnife = null;

    float _Speed = 5f;


    void Start()
    {
        for (int i = 0; i < 360; i += 45)
        {
            GameObject third = Instantiate(_thirdPoint);

            third.transform.position = this.transform.position;
            third.transform.rotation = Quaternion.Euler(0, 0, i);
            third.transform.SetParent(this.transform);
        }

        for (int i = 0; i < 360; i += 90)
        {
            GameObject knife = Instantiate(_thirdKnife);

            knife.transform.position = this.transform.position;
            knife.transform.rotation = Quaternion.Euler(0, 0, i);
            knife.transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        Vector3 dir = new Vector3(0, 0, _Speed * Time.deltaTime);

        this.transform.Rotate(dir.normalized);
    }
}