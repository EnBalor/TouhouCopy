using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _bullet = null;

    float fire = 0f;
    float delay = 0.1f;

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
                GameObject temp = Instantiate(_bullet);

                Destroy(temp, 1f);

                temp.transform.position = _player.transform.position;
                temp.transform.rotation = Quaternion.Euler(0, 0, i);
            }
        }
    }
}