using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reimu : MonoBehaviour
{
    GameManager _gm;

    [SerializeField]
    GameObject _player = null;

    [SerializeField]
    GameObject _bullet = null;

    [SerializeField]
    GameObject _chaser = null;

    [SerializeField]
    GameObject _bomb = null;

    Bullet_clear _bc;
    Guide_Manager _Gmanager;

    public AudioClip _shot;
    public AudioClip _bombsound;

    AudioSource audioSource;

    float fire = 0f;
    float delay = 0.1f;

    float _bombtime = 0.2f;
    float _bombdelay = 0.5f;

    public bool _clearBullet = false;
    public bool _isbomb = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _bc = GameObject.Find("BulletClear").GetComponent<Bullet_clear>();
    }

    void Update()
    {
        fire += Time.deltaTime;
        _bombdelay += Time.deltaTime;

        if(fire > delay)
        {
            Reimu_shot();
            fire = 0;
        }
    }
    
    void Reimu_shot()
    {
        if (_isbomb == false)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                audioSource.clip = _shot;
                audioSource.Play();

                for (int i = -10; i < 20; i += 10)
                {
                    GameObject bullet = Instantiate(_bullet);

                    Destroy(bullet, 1f);

                    bullet.transform.position = _player.transform.position;
                    bullet.transform.rotation = Quaternion.Euler(0, 0, i);
                }

                for (int i = -50; i <= 50; i += 25)
                {
                    GameObject chaser = Instantiate(_chaser);

                    Destroy(chaser, 1f);

                    if (i == 0)
                    {
                        i = 25;
                    }

                    chaser.transform.position = _player.transform.position;
                    chaser.transform.rotation = Quaternion.Euler(0, 0, i);
                }
            }
        }

        if (_gm._bomb > 0 && _bombdelay >= 0.4f)
        {
            if (Input.GetKey(KeyCode.X))
            {
                audioSource.clip = _bombsound;
                audioSource.Play();
                Bomb();
                _isbomb = true;
                _bc._bulletclear = true;
                _bombdelay = 0f;
            }
        }

        if (_bc._bulletclear == true)
        {
            _bombtime -= Time.deltaTime;
            if (_bombtime <= 0f)
            {
                _bc._bulletclear = false;
                _bombtime = 0.2f;
            }
        }

        if(_isbomb == true)
        {
            _gm._bomb -= 1;
            _isbomb = false;
        }
    }

    public void Bomb()
    {
        List<Transform> b1 = new List<Transform>();


        for (int i = 0; i < 360; i += 45)
        {
            GameObject bomb = Instantiate(_bomb);

            bomb.transform.position = _player.transform.position;

            b1.Add(bomb.transform);

            bomb.transform.rotation = Quaternion.Euler(0, 0, i);

            if (_bombtime <= 0)
            {
                Destroy(bomb, 5f);
            }
        }

        _bombtime -= Time.deltaTime;
        StartCoroutine(BombToTarget(b1));
    }

    IEnumerator BombToTarget(List<Transform> b1)
    {
        yield return new WaitForSeconds(0.5f);

        for(int i = 0; i < b1.Count; i++)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Enemy");

            if (target != null)
            {
                Vector3 dir = target.transform.position - b1[i].position;

                float _angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

                b1[i].rotation = Quaternion.Euler(0, 0, _angle);
            }
        }

        b1.Clear();
    }
}