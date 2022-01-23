using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletShowerController : MonoBehaviour
{
    private Vector3[] PointList = new Vector3[5];

    private void Start()
    {
        PointList = GetEndPoint();

        for (int i = 0; i < 5; ++i)
        {
            GameObject Obj = new GameObject(i.ToString());
            Obj.transform.position = PointList[i];
            Obj.transform.parent = transform;
            Obj.transform.gameObject.AddComponent<MyGizmo>();

            Obj.transform.gameObject.tag = "EndPoint";

            SphereCollider Coll = Obj.gameObject.AddComponent<SphereCollider>();
            Coll.radius = 0.2f;
        }
        ObjectManager.GetInstance.GetFlowerPointList = PointList;
    }

    Vector3[] GetEndPoint()
    {
        Vector3[] PointList = new Vector3[5];

        for (int i = 0; i < 5; ++i)
        {
            float Angle = ((180 / 6) * (i + 1)) + 180;

            Vector3 vPos = new Vector3(
                Mathf.Cos(Angle * Mathf.PI / 180) * 10,
                Mathf.Sin(Angle * Mathf.PI / 180) * 10,
                0.0f);

            PointList[i] = vPos + transform.position;
        }
        return PointList;
    }
}
