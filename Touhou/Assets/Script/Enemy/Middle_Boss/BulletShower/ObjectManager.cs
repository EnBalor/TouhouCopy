using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    private static ObjectManager Instance = null;

    public static ObjectManager GetInstance
    {
        get
        {
            if (Instance == null)
                Instance = new ObjectManager();
            return Instance;
        }
    }

    private Vector3[] FlowerPointList = new Vector3[5];
    public Vector3[] GetFlowerPointList {
        get
        {
            return FlowerPointList;
        } 
        set
        {
            FlowerPointList = value;
        }
    }
}
