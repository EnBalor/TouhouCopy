using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBulletmanager : MonoBehaviour
{
    [SerializeField]
    GameObject _bullet = null;
    
    private float BulletTime = 0.0f;

    private bool CreateBulletTime;
    private bool BulletShower = false;

    private List<GameObject> BulletList = new List<GameObject>();

    Boss_Manager _bm;

    private void Awake()
    {
        new GameObject("BulletList");
    }

    void Start()
    {
        _bm = GameObject.Find("Mokou").GetComponent<Boss_Manager>();

        BulletTime = 12.0f;

        BulletShower = true;
        CreateBulletTime = true;
    }

    private void Update()
    {
        if (_bm._fstpattern == true)
        {
            BulletTime -= Time.deltaTime;

            if (BulletTime < 0)
            {
                BulletShower = false;
                BulletTime = 12.0f;
            }

            if(CreateBulletTime)
            {
                GameObject Obj = Instantiate(_bullet);
                Obj.transform.position = this.transform.position;
                //GameObject Obj = new GameObject("Bullet");

                Obj.transform.gameObject.AddComponent<BulletController>();

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
