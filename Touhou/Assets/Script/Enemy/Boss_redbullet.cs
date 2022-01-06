using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_redbullet : MonoBehaviour
{
    [SerializeField]
    GameObject _end = null;

    float _speed = 3f;

    float _boost = 0f;
    float _waitTime = 0.8f;
    float _boostTime = 0.9f;

    public List<GameObject> findend;
    float _short;

    private void Start()
    {
        findend = new List<GameObject>(GameObject.FindGameObjectsWithTag("Endbullet"));
        _short = Vector3.Distance(this.transform.position, findend[0].transform.position);
    }

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);

        _boost += Time.deltaTime;

        if(_boost >= _waitTime)
        {
            _speed = 0f;
        }

        if(_boost >= _boostTime)
        {

            _speed = 5f;

            _end = findend[0];

            foreach (GameObject find in findend)
            {
                float _distance = Vector3.Distance(gameObject.transform.position, find.transform.position);

                if(_distance < _short)
                {
                    _end = find;
                    _short = _distance;
                }
            }

            Vector3 _chaser = findend[0].transform.position - this.transform.position;

            transform.Translate(_chaser * _speed * Time.deltaTime, Space.Self);

        }
    }
}
