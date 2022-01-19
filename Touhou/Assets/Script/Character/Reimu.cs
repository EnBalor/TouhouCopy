using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{
    GameManager _gm;

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _chaser = null;

    [SerializeField]
    GameObject _bomb = null;

    float fire = 0f;
    float delay = 0.1f;

    float _bombdly = 0f;
    float _bombDelay = 5f;

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        fire += Time.deltaTime;

        if(fire > delay)
        {
            Reimu_shot();
            fire = 0;
        }
    }

    void Reimu_shot()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            for (int i = -10; i < 20; i += 10)
            {
                GameObject bullet = Instantiate(_bullet);

                Destroy(bullet, 1f);

                bullet.transform.position = _player.transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, i);
            }

            for (int i = -50; i <= 50; i += 25)
            {
                GameObject chaser = Instantiate(_chaser);

                Destroy(chaser, 1f);

                if(i == 0)
                {
                    i = 25;
                }

                chaser.transform.position = _player.transform.position;
                chaser.transform.rotation = Quaternion.Euler(0, 0, i);
            }
        }
        if (_gm._bomb > 0)
        {
            if (Input.GetKey(KeyCode.X))
            {
                Bomb();
                _gm._bomb -= 1;
            }
        }
    }

    void Bomb()
    {
        List<Transform> b1 = new List<Transform>();

        for(int i = 0; i < 360; i += 45)
        {
            GameObject bomb = Instantiate(_bomb);

            bomb.transform.position = _player.transform.position;

            b1.Add(bomb.transform);

            bomb.transform.rotation = Quaternion.Euler(0, 0, i);
        }

        StartCoroutine(BombToTarget(b1));
    }

    IEnumerator BombToTarget(List<Transform> b1)
    {
        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < b1.Count; i++)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Enemy");

            Vector3 dir = target.transform.position - b1[i].transform.position;

            float _angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            b1[i].rotation = Quaternion.Euler(0, 0, _angle);
        }

        b1.Clear();
    }
}