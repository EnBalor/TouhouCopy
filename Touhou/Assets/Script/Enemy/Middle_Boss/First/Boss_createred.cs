using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_createred : MonoBehaviour
{
    private float BulletTime = 0.0f;

    private bool CreateBulletTime;
    private bool BulletShower = false;

    private List<GameObject> BulletList = new List<GameObject>();

    private void Awake()
    {
        new GameObject("BulletList");
    }

    void Start()
    {
        BulletTime = 12.0f;

        BulletShower = true;
        CreateBulletTime = true;
    }

    private void Update()
    {
        if (BulletShower)
        {
            BulletTime -= Time.deltaTime;

            if (BulletTime < 0)
            {
                BulletShower = false;
                BulletTime = 12.0f;
            }

            if (CreateBulletTime)
            {
                GameObject Obj = new GameObject("Bullet");

                Obj.transform.gameObject.AddComponent<BulletController>();

                Rigidbody Rigid = Obj.transform.gameObject.AddComponent<Rigidbody>();
                Rigid.useGravity = false;

                SphereCollider Coll = Obj.transform.gameObject.AddComponent<SphereCollider>();
                Coll.radius = 0.1f;
                Coll.isTrigger = true;

                //Obj.transform.gameObject.AddComponent<MyGizmo>();

                Obj.transform.parent = GameObject.Find("BulletList").transform;

                Obj.gameObject.layer = 6;

                BulletList.Add(Obj);

                CreateBulletTime = false;
                StartCoroutine("SetCreateTime");
            }

        }
    }

    IEnumerator SetCreateTime()
    {
        yield return new WaitForSeconds(0.1f);
        CreateBulletTime = true;
    }
}
