using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shotController : MonoBehaviour
{
    public float _rotSpeed = 10.0f;

    [SerializeField]
    GameObject _bullet = null;

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        for (int i = 0; i < 360; i += 90)
        {
            GameObject bullet = Instantiate(_bullet);

            yield return new WaitForSeconds(0.5f);
            this.transform.Rotate(0, 0, Time.deltaTime * _rotSpeed, Space.Self);
        }
    }
}