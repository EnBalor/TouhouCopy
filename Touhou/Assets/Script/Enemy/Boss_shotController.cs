using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shotController : MonoBehaviour
{
    public float _rotSpeed = 200.0f;

    [SerializeField]
    GameObject _bullet = null;

    void Start()
    {
        StartCoroutine(Fire());

    }

    void Update()
    {

    }

    IEnumerator Fire()
    {
        for (int i = 0; i < 360; i++)
        {
            for (int j = 0; j < 360; j += 90)
            {
                yield return new WaitForSeconds(0.04f);
                GameObject bullet = Instantiate(_bullet);
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, j);

                this.transform.Rotate(0, 0, _rotSpeed * Time.deltaTime);

                Destroy(bullet, 3f);
            }
        }
    }
}