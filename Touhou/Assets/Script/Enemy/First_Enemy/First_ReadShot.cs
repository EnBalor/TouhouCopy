using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_ReadShot : MonoBehaviour
{
    void Start()
    {
        GameObject target = GameObject.Find("Player");
        this.transform.position = target.transform.position;
    }

    void Update()
    {
        
    }
}
