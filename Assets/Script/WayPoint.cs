﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static Transform[] point;
    // Start is called before the first frame update
    void Awake()
    {
        point = new Transform[transform.childCount];
        for(int i = 0; i < point.Length; i++)
        {
            point[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
