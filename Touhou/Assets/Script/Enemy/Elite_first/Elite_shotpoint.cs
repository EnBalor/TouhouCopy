using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elite_shotpoint : MonoBehaviour
{

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
        yield return new WaitForSeconds(1.0f);

        for (int i = -0; i < 3; i ++)
        {
            yield return new WaitForSeconds(0.001f);
            _bullet.transform.position = this.transform.position;


            for (int j = -10; j < 10; j+= 10)
            {
                yield return new WaitForSeconds(0.01f);
                GameObject bullet = Instantiate(_bullet);
                bullet.transform.rotation = Quaternion.Euler(0, 0, j);
                bullet.transform.rotation = this.transform.rotation;

                Destroy(bullet, 5f);
            }
        }
    }
}
