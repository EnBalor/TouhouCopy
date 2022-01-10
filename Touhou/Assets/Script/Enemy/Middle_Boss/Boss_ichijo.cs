using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ichijo : MonoBehaviour
{
    [SerializeField]
    GameObject _leftShotPoint = null;

    [SerializeField]
    GameObject _RightShotPoint = null;

    

    bool _isFire = false;

    void Start()
    {

        for (int i = 0; i < 360; i += 90)
        {
            GameObject leftShotPoint = Instantiate(_leftShotPoint);
            GameObject rightShotPoint = Instantiate(_RightShotPoint);

            leftShotPoint.transform.position = this.transform.position;
            leftShotPoint.transform.rotation = Quaternion.Euler(0, 0, i);

            rightShotPoint.transform.position = this.transform.position;
            rightShotPoint.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    void Update()
    {
        
    }
}