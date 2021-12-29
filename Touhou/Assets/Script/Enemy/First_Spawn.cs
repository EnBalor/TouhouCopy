using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject _firstEnemy;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(1f);
            GameObject firstEnemy = Instantiate(_firstEnemy);
            _firstEnemy.transform.position = this.transform.position;
            Destroy(firstEnemy, 5f);
        }
    }
}
