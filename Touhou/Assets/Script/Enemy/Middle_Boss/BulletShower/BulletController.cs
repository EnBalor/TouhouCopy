using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletController : MonoBehaviour
{
    //부모 위치
    private Vector3 ParentPosition;

    private float Speed;

    private Vector3 Direction;

    private float DelayTime = 0.0f;

    private float WaveTime = 5.0f;

    private bool Pattern_01;
    
    private bool[] WaveCheck = new bool[2];

    [System.Obsolete]
    private void Start()
    {
        //아마 위치 기본값이 0, 0, 0 이라 이렇게 한듯
        ParentPosition = new Vector3(0.0f, 0.0f, 0.0f);

        //흠 속도...
        Speed = 0.8f;

        // **************************************************
        // *  총알이 랜덤한 방향으로 나갈수 있도록 방향을 구함.
        // **************************************************
        //방향 구하는 거인듯
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        //각도 값 랜덤
        float Angle = Random.RandomRange(0, 180) + 180;

        //사인 코사인
        Vector3 vPos = new Vector3(
            Mathf.Cos(Angle * Mathf.PI / 180),
            Mathf.Sin(Angle * Mathf.PI / 180),
            0.0f);


        //방향은 사인 코사인 계산 값의 노멀라이즈
        Direction = vPos.normalized;
        // **************************************************

        DelayTime = 0.5f;

        Pattern_01 = true;

        WaveCheck[0] = true;
        WaveCheck[1] = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Pattern_01 = true;
        }

        if(Pattern_01)
        {
            if (WaveCheck[0])
            {
                //거리는 벡터3.(부모 포지션, 이 스크립트 포지션)
                float Distance = Vector3.Distance(ParentPosition, transform.position);

                //방향으로 이동
                transform.Translate(Direction * Speed * Time.deltaTime);

                //패턴 실행 시간 델타타임으로 감소
                WaveTime -= Time.deltaTime;

                //시간 되면 0번 패턴 false
                if (WaveTime < 0.0f && WaveCheck[1])
                    WaveCheck[0] = false;
            }
            else
            {
                DelayTime -= Time.deltaTime;

                if (DelayTime < 0.0f)
                {
                    DelayTime = 0.5f;

                    //도착지 리스트
                    Vector3[] GetFlowerPointList = new Vector3[5];

                    //도착지리스트 = 오브젝트매니저 참조
                    GetFlowerPointList = (Vector3[])ObjectManager.GetInstance.GetFlowerPointList.Clone();

                    //
                    Dictionary<float, Vector3> Compare = new Dictionary<float, Vector3>();

                    //반복문으로 가장 가까운 거리 찾아가기?
                    for (int i = 0; i < 5; ++i)
                    {
                        float fDis = (float)Vector3.Distance(GetFlowerPointList[i], transform.position);

                        if (Compare.ContainsKey(fDis) == false)
                            Compare.Add(fDis, GetFlowerPointList[i]);
                        else
                            continue;
                    }

                    var Result = Compare.OrderBy(x => x.Key);

                    Vector3 vPos = Result.First().Value;

                    Direction = (vPos - transform.position).normalized;

                    WaveCheck[0] = true;
                    WaveCheck[1] = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EndPoint")
        {
            Pattern_01 = false;
            WaveCheck[1] = true;

            Destroy(transform.gameObject);
        }
    }
}
