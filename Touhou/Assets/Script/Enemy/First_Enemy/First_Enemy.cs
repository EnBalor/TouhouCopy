using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameManager _gameManager = null;

    private void Start()
    {
        StartCoroutine(Fire());
        _gameManager = GetComponent<GameManager>();
        _gameManager._isEnemy = true;
    }

    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                yield return new WaitForSeconds(0.001f);
                GameObject bullet = Instantiate(_bullet);
                _bullet.transform.position = this.transform.position;
                Destroy(bullet, 2f);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}