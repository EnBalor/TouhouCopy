using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_clear : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy_bullet")
        {
            Destroy(collision);
        }
    }
}
