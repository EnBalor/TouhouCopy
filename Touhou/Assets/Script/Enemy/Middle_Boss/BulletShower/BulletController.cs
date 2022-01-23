using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletController : MonoBehaviour
{
    //�θ� ��ġ
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
        //�Ƹ� ��ġ �⺻���� 0, 0, 0 �̶� �̷��� �ѵ�
        ParentPosition = new Vector3(0.0f, 0.0f, 0.0f);

        //�� �ӵ�...
        Speed = 0.8f;

        // **************************************************
        // *  �Ѿ��� ������ �������� ������ �ֵ��� ������ ����.
        // **************************************************
        //���� ���ϴ� ���ε�
        Direction = new Vector3(0.0f, 0.0f, 0.0f);

        //���� �� ����
        float Angle = Random.RandomRange(0, 180) + 180;

        //���� �ڻ���
        Vector3 vPos = new Vector3(
            Mathf.Cos(Angle * Mathf.PI / 180),
            Mathf.Sin(Angle * Mathf.PI / 180),
            0.0f);


        //������ ���� �ڻ��� ��� ���� ��ֶ�����
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
                //�Ÿ��� ����3.(�θ� ������, �� ��ũ��Ʈ ������)
                float Distance = Vector3.Distance(ParentPosition, transform.position);

                //�������� �̵�
                transform.Translate(Direction * Speed * Time.deltaTime);

                //���� ���� �ð� ��ŸŸ������ ����
                WaveTime -= Time.deltaTime;

                //�ð� �Ǹ� 0�� ���� false
                if (WaveTime < 0.0f && WaveCheck[1])
                    WaveCheck[0] = false;
            }
            else
            {
                DelayTime -= Time.deltaTime;

                if (DelayTime < 0.0f)
                {
                    DelayTime = 0.5f;

                    //������ ����Ʈ
                    Vector3[] GetFlowerPointList = new Vector3[5];

                    //����������Ʈ = ������Ʈ�Ŵ��� ����
                    GetFlowerPointList = (Vector3[])ObjectManager.GetInstance.GetFlowerPointList.Clone();

                    //
                    Dictionary<float, Vector3> Compare = new Dictionary<float, Vector3>();

                    //�ݺ������� ���� ����� �Ÿ� ã�ư���?
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