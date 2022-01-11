using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreamin_Red : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    public float _speed = 7f;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject _spawnPoint = transform.parent.gameObject;

        float _distance = Vector3.Distance(this.transform.position, _spawnPoint.transform.position);

        transform.Translate(Vector3.down * Time.deltaTime * _speed, Space.Self);

        if (_distance >= 5f)
        {
            _speed = 0f;
        }

    }
}
