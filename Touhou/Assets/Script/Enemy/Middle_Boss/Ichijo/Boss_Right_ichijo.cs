using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Right_ichijo : MonoBehaviour
{
    [SerializeField]
    GameObject _RightShotPoint = null;


    public float _rotSpeed = 5f;

    bool _isFire = false;

    void Start()
    {
        if (_isFire == true)
        {
            for (int i = 0; i < 360; i += 90)
            {
                GameObject rightShotPoint = Instantiate(_RightShotPoint);

                rightShotPoint.transform.position = this.transform.position;
                rightShotPoint.transform.rotation = Quaternion.Euler(0, 0, i);
                rightShotPoint.transform.SetParent(this.transform);
            }
        }
    }

    void Update()
    {
        this.transform.Rotate(0, 0, -(_rotSpeed * Time.deltaTime));
    }
}