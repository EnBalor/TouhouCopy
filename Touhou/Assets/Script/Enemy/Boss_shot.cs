using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shot : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator Fire()
    {
        for(int i = -90; i < 90; i += 90)
        {
            yield return new WaitForSeconds(1f);


        }
    }
}
