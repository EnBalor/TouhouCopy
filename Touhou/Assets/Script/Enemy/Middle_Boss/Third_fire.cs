using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_fire : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;
    
    float _delay = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        _delay -= Time.deltaTime;

        if (_delay <= 0)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;

            _delay = 0.2f;

            Destroy(bullet, 3f);
        }
    }
}
