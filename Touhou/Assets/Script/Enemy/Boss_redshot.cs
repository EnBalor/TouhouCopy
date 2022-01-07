using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_redshot : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;


    //총알 도착지
    [SerializeField]
    GameObject _end = null;


    //패턴 진행 시간
    float _pattern = 0f;
    float _patternTime = 2f;

    //총알 발사 딜레이
    float _fire = 0.1f;
    float _delay = 0.1f;

    public float _speed = 5f;

    void Start()
    {
        //총알 도착지 생성, 반복문으로 15f 거리에 원형으로 생성
        for (int i = 160; i < 400; i += 20)
        {
            //위치값을 원형으로 생성
            Vector3 pos = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0);

            GameObject end = Instantiate(_end);
            end.transform.right = pos;
            end.transform.position = pos * 15f;
        }
    }

    void Update()
    {
        _fire += Time.deltaTime;
        _pattern += Time.deltaTime;

        if (_pattern >= _patternTime)
        {
            if (_fire >= _delay)
            {
                GameObject target = GameObject.FindGameObjectWithTag("Player");

                GameObject bullet = Instantiate(_bullet);
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, 0, Random.Range(120, -120));

                Vector3 dir = target.transform.position - this.transform.position;
                dir.Normalize();

                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                Destroy(bullet, 3f);
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //
    //    for (int i = 160; i < 400; i += 20)
    //    {
    //        //위치값을 원형으로 생성
    //        Vector3 pos = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0);
    //
    //        Gizmos.DrawWireSphere(this.transform.position, 1f);
    //
    //    }
    //}

}
