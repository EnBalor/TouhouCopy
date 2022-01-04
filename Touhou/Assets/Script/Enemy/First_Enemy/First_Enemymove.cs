using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Enemymove : MonoBehaviour
{
    [SerializeField]
    GameObject _first = null;

    public float _speed = 5.0f;
    public float _rotspeed = 100.0f;

    float _limit = 0;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * Time.deltaTime * _speed);
        StartCoroutine(Rot());
    }

    IEnumerator Rot()
    {
        yield return new WaitForSeconds(1.0f);

        if (this.transform.position.x >= 0)
        {
            _first.transform.Rotate(0, 0, _rotspeed * Time.deltaTime);
        }

        else if (this.transform.position.x <= 0)
        {
            _first.transform.Rotate(0, 0, -(_rotspeed * Time.deltaTime));

        }
    }
}
