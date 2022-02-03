using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_knifesoht : MonoBehaviour
{
    [SerializeField]
    GameObject _knife = null;

    float _knifedelay = 0.2f;

    void Start()
    {
        
    }

    void Update()
    {
        _knifedelay -= Time.deltaTime;

        if (_knifedelay <= 0)
        {
            GameObject knife = Instantiate(_knife);
            knife.transform.position = this.transform.position;
            knife.transform.rotation = this.transform.rotation;

            _knifedelay = 0.2f;

            Destroy(knife, 5f);
        }

    }
}
