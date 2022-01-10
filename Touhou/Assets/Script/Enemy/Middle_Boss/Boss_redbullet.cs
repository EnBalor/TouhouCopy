using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_redbullet : MonoBehaviour
{
    //총알 도착지
    [SerializeField]
    GameObject _end = null;

    [SerializeField]
    Boss_redshot _shotpoint;

    float _speed = 3f;

    //발사 시간 조절
    float _boost = 0f;
    float _waitTime = 0.8f;
    float _boostTime = 0.9f;

    //총알 도착지 리스트
    public List<GameObject> _findend = new List<GameObject>();

    //가장 짧은 거리를 담는 변수
    float _short;

    public Transform _sphere;

    bool _isFire = false;

    private void Start()
    {
        //endbullet 태그를 참조해 가장 가까운 endbullet를 찾음
        _findend = new List<GameObject>(GameObject.FindGameObjectsWithTag("Endbullet"));
    }

    void Update()
    {
        if (_isFire == true)
        {
            for (int i = 160; i < 400; i += 20)
            {
                //위치값을 원형으로 생성
                Vector3 pos = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0);
            }

            //총알 이동(up으로 하면 총알이 제대로 나가는데 방향이 달라...)
            transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.Self);

            _boost += Time.deltaTime;

            //총알 정지
            if (_boost >= _waitTime)
            {
                _speed = 0f;
            }

            //총알 가속
            if (_boost >= _boostTime)
            {
                _speed = 5f;

                //가장 가까운 거리 구하기
                for (int i = 0; i < 12; i++)
                {
                    _short = Vector3.Distance(this.transform.position, _findend[i].transform.position);

                    _end = _findend[i];
                }

                //너를 우짜면 좋니...
                foreach (GameObject find in _findend)
                {
                    float _distance = Vector3.Distance(gameObject.transform.position, find.transform.position);

                    for (int i = 0; i < 12; i++)
                    {
                        if (_distance < _short)
                        {
                            _end = find;
                            _short = _distance;
                        }

                        Vector3 _chaser = _findend[i].transform.position - this.transform.position;
                        transform.Translate(_chaser * _speed * Time.deltaTime, Space.Self);
                    }
                }
            }
        }
    }
}
