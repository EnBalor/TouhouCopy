using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _pattern1 = null;

    [SerializeField]
    GameObject _pattern2 = null;

    [SerializeField]
    GameObject _pattern3 = null;

    [SerializeField]
    GameObject _pattern4 = null;

    [SerializeField]
    GameObject _leftichijo = null;

    [SerializeField]
    GameObject _rightichijo = null;

    [SerializeField]
    GameObject _third = null;

    Animator animator;
    string animationState = "AnimationState";

    Bullet_clear _bc;

    public int _firstHP = 1000;
    public int _ichijoHP = 1000;
    public int _thirdHP = 1000;

    float _delay = 0f;
    float _first = 3f;

    Boss_shotController _firstPattern;
    Boss_Left_ichijo _secondPattern;
    Boss_Right_ichijo _secondPattern2;
    ScoreManager _sc;

    public bool _spawn;
    public bool _fstpattern;
    public bool _ichijopattern;
    public bool _thidpattern;

    enum States
    {
        idle = 0,
        spawn = 1,
        fire = 2
    }

    void Start()
    {
        _bc = GameObject.Find("BulletClear").GetComponent<Bullet_clear>();

        _firstPattern = GetComponent<Boss_shotController>();

        _secondPattern = GetComponent<Boss_Left_ichijo>();
        _secondPattern2 = GetComponent<Boss_Right_ichijo>();

        _pattern1.SetActive(false);
        _pattern2.SetActive(false);
        _pattern3.SetActive(false);
        _pattern4.SetActive(false);

        _leftichijo.SetActive(false);
        _rightichijo.SetActive(false);

        _third.SetActive(false);
    }

    void Update()
    {
        _delay += Time.deltaTime;

        if(_delay >= _first)
        {
            _fstpattern = true;
            _pattern1.SetActive(true);
            _pattern2.SetActive(true);
            _pattern3.SetActive(true);
            _pattern4.SetActive(true);
        }

        if(_firstHP <= 0)
        {
            _fstpattern = false;
            _pattern1.SetActive(false);
            _pattern2.SetActive(false);
            _pattern3.SetActive(false);
            _pattern4.SetActive(false);

            _bc._bulletclear = false;
            _ichijopattern = true;
            _leftichijo.SetActive(true);
            _rightichijo.SetActive(true);
        }

        if(_ichijoHP <= 0)
        {
            _ichijopattern = false;
            _leftichijo.SetActive(false);
            _rightichijo.SetActive(false);

            _thidpattern = true;
            _third.SetActive(true);
        }

        if(_thirdHP <= 0)
        {
            _firstHP = 1000;
            _ichijoHP = 1000;
            _thirdHP = 1000;

            _thidpattern = false;
            _fstpattern = true;
            _pattern1.SetActive(true);
            _pattern2.SetActive(true);
            _pattern3.SetActive(true);
            _pattern4.SetActive(true);
        }

        if(_firstHP == 1000)
        {
            _third.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _firstHP -= 1000;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _firstHP -= 1000;
            _ichijoHP -= 1000;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _firstHP -= 1000;
            _ichijoHP -= 1000;
            _thirdHP -= 1000;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_bullet")
        {
            if (_firstHP >= 0)
            {
                _firstHP -= 1;
                Debug.Log("bosshit");
            }
            else if (_firstHP <= 0)
            {
                _ichijoHP -= 1;
                Debug.Log("ichijoHit");
            }

            if (_ichijoHP <= 0)
            {
                _thirdHP -= 1;
                Debug.Log("thirdHit");
            }

            ScoreManager.Instance.addscore(10);
        }

        if(collision.tag == "Bomb")
        {
            if (_firstHP >= 0)
            {
                _firstHP -= 50;
            }
            else if (_firstHP <= 0)
            {
                _ichijoHP -= 50;
            }

            else if (_ichijoHP <= 0)
            {
                _thirdHP -= 50;
            }
        }
    }

    public void State()
    {
        if(_firstPattern == true)
        {
            animator.SetInteger(animationState, (int)States.fire);
        }

        else
        {
            animator.SetInteger(animationState, (int)States.idle);
        }
    }
}
