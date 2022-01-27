using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tedt : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy_bullet")
        {
            Debug.Log("test");
        }
    }
}
