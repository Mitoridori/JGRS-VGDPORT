﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    private float baseTurnRate = 45.0f;
    private float baseLookUpRate = 45.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetTurnRate()
    {
        return baseTurnRate;
    }

    public float GetLookUpRate()
    {
        return baseLookUpRate;
    }
}
