using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _chaser = null;

    float fire = 0f;
    float delay = 0.1f;

    private void Start()
    {
        
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
    }
}