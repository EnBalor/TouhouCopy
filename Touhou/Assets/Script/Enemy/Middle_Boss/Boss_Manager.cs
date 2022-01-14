using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _boss = null;

    [SerializeField]
    GameObject _pattern1 = null;

    [SerializeField]
    GameObject _pattern2 = null;

    [SerializeField]
    GameObject _pattern3 = null;

    [SerializeField]
    GameObject _pattern4 = null;

    public int _firstHP = 1000;
    public int _ichijoHP = 1000;

    float _delay = 0f;
    float _first = 2f;

    Boss_shotController _firstPattern;
    Boss_redshot _firstRed;

    Boss_Left_ichijo _secondPattern;
    Boss_Right_ichijo _secondPattern2;

    void Start()
    {
        _firstPattern = GetComponent<Boss_shotController>();
        _firstRed = GetComponent<Boss_redshot>();

        _secondPattern = GetComponent<Boss_Left_ichijo>();
        _secondPattern2 = GetComponent<Boss_Right_ichijo>();

        _pattern1.SetActive(false);
        _pattern2.SetActive(false);
        _pattern3.SetActive(false);
        _pattern4.SetActive(false);
    }

    void Update()
    {
        _delay += Time.deltaTime;

        if(_delay >= _first)
        {
            _firstPattern._isFire = true;
            _pattern1.SetActive(true);
            _pattern2.SetActive(true);
            _pattern3.SetActive(true);
            _pattern4.SetActive(true);
        }

        if(_firstHP <= 0)
        {
            _firstPattern._isFire = false;
            _pattern1.SetActive(false);
            _pattern2.SetActive(false);
            _pattern3.SetActive(false);
            _pattern4.SetActive(false);

            _secondPattern._isFire = true;
            //_secondPattern2._isFire = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player_bullet")
        {
            _firstHP -= 1;
            Debug.Log("bosshit");
        }
    }
}
