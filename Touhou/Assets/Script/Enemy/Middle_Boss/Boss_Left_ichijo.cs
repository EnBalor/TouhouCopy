using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Left_ichijo : MonoBehaviour
{
    [SerializeField]
    GameObject _leftShotPoint = null;

    public float _rotSpeed = 5f;

    bool _isFire = false;

    void Start()
    {
        for (int i = 0; i < 360; i += 90)
        {
            GameObject leftShotPoint = Instantiate(_leftShotPoint);
        
            leftShotPoint.transform.position = this.transform.position;
            leftShotPoint.transform.rotation = Quaternion.Euler(0, 0, i);
            leftShotPoint.transform.SetParent(this.transform);
        }
    }

    void Update()
    {
        this.transform.Rotate(0, 0, _rotSpeed * Time.deltaTime);
    }
}