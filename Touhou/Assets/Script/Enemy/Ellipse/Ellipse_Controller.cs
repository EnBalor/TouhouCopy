using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    Vector3 dir;

    public float _speed;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    void Update()
    {
        StartCoroutine(EnemyMove());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.2f);

        
        for (int i = -10; i < 0; i += 1)
        {
            yield return new WaitForSeconds(0.001f);
            _bullet.transform.position = this.transform.position;


            for (int j = 0; j < 3; j++)
            {
                yield return new WaitForSeconds(0.01f);
                GameObject bullet = Instantiate(_bullet);
                bullet.transform.rotation = Quaternion.Euler(0, 0, i);
                
                Destroy(bullet, 5f);
            }
        }
    }

    IEnumerator EnemyMove()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(this.transform.position.y <= 2)
        {
            _speed -= 1f;
            if(_speed <= 0)
            {
                _speed = 0f;
            }
        }

        yield return new WaitForSeconds(3.0f);

        this.transform.Translate(Vector3.up * Time.deltaTime * 5f);
    }
}
