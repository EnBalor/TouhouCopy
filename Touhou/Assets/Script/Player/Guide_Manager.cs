using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject _player = null;

    SpriteRenderer _renderer;

    public float _speed = 5f;

    void Start()
    {
        _renderer = this.GetComponent<SpriteRenderer>();
        _renderer.enabled = false;
    }

    void Update()
    {
        Vector3 dir = new Vector3(0, 0, _speed * Time.deltaTime);

        this.transform.Rotate(-(dir.normalized));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _renderer.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _renderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_bullet")
        {
            Debug.Log("dest");
            Destroy(_player);
        }
    }
}
